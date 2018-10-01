using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour {
	private float hoverForce =7f;
	ArrayList levelLanding = new ArrayList();
	GameObject flagTR,flagTL,flagBR,flagBL,landingPlane,landingZone;
	private float width,height;
	private Vector3 middle;
	public GameObject instanceScript;
	level levelInstance;
	MeshFilter mf;
	MeshRenderer mr;
	Mesh m ;
	// Use this for initialization
	void Start () {
		levelInstance = instanceScript.GetComponent<level>();
		flagTR = GameObject.Find("topRight");
		flagTL = GameObject.Find("topLeft");
		flagBR = GameObject.Find("bottomRight");
		flagBL = GameObject.Find("bottomLeft");
		landingPlane = GameObject.Find("landingPlane");
		landingZone = GameObject.Find("landingZone");
		levelLanding.Add(false);
		levelLanding.Add(false);
		levelLanding.Add(false);
		mf = landingPlane.AddComponent(typeof(MeshFilter)) as MeshFilter;
		mr = landingPlane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		m = new Mesh();
		setLanding();
	
}
	
	// Update is called once per frame
	void Update () {
		if(levelInstance.levelLanding ==1 && levelLanding[1].Equals(false)){
			print("here");
			Vector3 pos = landingZone.transform.position;
			landingZone.transform.localScale = new Vector3(1f,1f,0.6f);
			landingZone.transform.position = new Vector3(pos.x,pos.y,pos.z + 2.5f);
			levelLanding[1]=true;
			setLanding();
		}
		else
			if(levelInstance.levelLanding ==2 && levelLanding[2].Equals(false)){
				print("here");
				Vector3 pos = landingZone.transform.position;
				landingZone.transform.localScale = new Vector3(1f,1f,0.3f);
				landingZone.transform.position = new Vector3(pos.x,pos.y,pos.z + 5f);
				levelLanding[2]=true;
				setLanding();
			}
	}

	// void OnTriggerStay (Collider other){

	// 	other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce,ForceMode.Acceleration);
	// }
	void OnCollisionEnter(Collision col){
		if(col.transform.name=="RobotJump"){
			
		}
	}
	float getWidth(GameObject tr,GameObject tl){
		float width = Mathf.Sqrt(Mathf.Pow(tl.transform.position.x-tr.transform.position.x,2));
		return width;
	}
	float getHeight(GameObject br,GameObject tr){
		float height = Mathf.Sqrt(Mathf.Pow(tr.transform.position.z-br.transform.position.z,2));
		return height;
	}
	void setPlane(){
		m.vertices = new Vector3[]{
			new Vector3(0,0,0),
			new Vector3(width,0,0),
			new Vector3(width,height,0),
			new Vector3(0,height,0)
		};
		m.uv = new Vector2[]{
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,1),
			new Vector2(1,0)
		};
		m.triangles = new int[]{0,1,2,0,2,3};
		mf.mesh = m;
		if(landingPlane.GetComponent<MeshCollider>() == null){
			(landingPlane.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
		}
		else{
			Destroy(landingPlane.GetComponent<MeshCollider>());
			(landingPlane.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
		}
		m.RecalculateBounds();
		m.RecalculateNormals();
		landingPlane.transform.eulerAngles = new Vector3(-90,0,0);
		landingPlane.transform.position = flagTL.transform.position;
		levelLanding[0] = true;
	}
	void changePlane(){

	}
	void setLanding(){
		width = getWidth(flagTR,flagTL);
		height = getHeight(flagBR,flagTR);
		setPlane();
	}
}

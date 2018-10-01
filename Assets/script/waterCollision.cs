using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour {
	private float hoverForce =7f;
	GameObject flagTR,flagTL,flagBR,flagBL,LandingPlane;
	private float width,height;
	private Vector3 middle;
	// Use this for initialization
	void Start () {
		flagTR = GameObject.Find("topRight");
		flagTL = GameObject.Find("topLeft");
		flagBR = GameObject.Find("bottomRight");
		flagBL = GameObject.Find("bottomLeft");
		LandingPlane = GameObject.Find("landingPlane");
		width = getWidth(flagTR,flagTL);
		height = getHeight(flagBR,flagTR);
		setPlane();
	}
	
	// Update is called once per frame
	void Update () {
		
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
		MeshFilter mf = LandingPlane.AddComponent(typeof(MeshFilter)) as MeshFilter;
		MeshRenderer mr = LandingPlane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		Mesh m = new Mesh();
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
		(LandingPlane.AddComponent(typeof(MeshCollider)) as MeshCollider).sharedMesh = m;
		m.RecalculateBounds();
		m.RecalculateNormals();
		LandingPlane.transform.eulerAngles = new Vector3(-90,0,0);
		LandingPlane.transform.position = flagTL.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour {
	private float hoverForce =7f;
	GameObject flagTR,flagTL,flagBR,flagBL,LandingPlane,LandingZone;
	private float width,height;
	// Use this for initialization
	void Start () {
		flagTR = GameObject.Find("topRight");
		flagTL = GameObject.Find("topLeft");
		flagBR = GameObject.Find("bottomRight");
		flagBL = GameObject.Find("bottomLeft");
		width = getWidth(flagTR,flagTL);
		height = getHeight(flagBR,flagTR);
		Helper.CreatePlane(width,height);
		LandingPlane = GameObject.Find("landingPlane");
		LandingPlane.transform.position = flagBL.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other){

		other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce,ForceMode.Acceleration);
	}
	float getWidth(GameObject tr,GameObject tl){
		float width = Mathf.Sqrt(Mathf.Pow(tl.transform.position.x-tr.transform.position.x,2));
		return width;
	}
	float getHeight(GameObject br,GameObject tr){
		float height = Mathf.Sqrt(Mathf.Pow(tr.transform.position.z-br.transform.position.z,2));
		return height;
	}	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterCollision : MonoBehaviour {
	private float hoverForce =7f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider other){
		other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce,ForceMode.Acceleration);
	}
}

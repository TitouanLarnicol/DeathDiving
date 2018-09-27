using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trick : MonoBehaviour {

	private Transform child;
	void Start () {
		child = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
			transform.DetachChildren();			
		}
		if(Input.GetKey(KeyCode.Space)){
	 		transform.Rotate(0.8f,0,0);			
		}
		
	}
}

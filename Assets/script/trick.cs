using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingText : MonoBehaviour {
	public float DestroyedTime =0.5f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,DestroyedTime); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

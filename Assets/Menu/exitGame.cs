using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour {
	public GameObject text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponentInChildren<GameObject>(); 
		print(text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}

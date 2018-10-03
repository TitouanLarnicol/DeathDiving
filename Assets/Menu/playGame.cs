using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playGame : MonoBehaviour{
	// Use this for initialization
	GameObject text;
	void Start () {		
		text = GameObject.Find("playgame");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 public void onIt()
     {
		this.GetComponent<Animation>().Play();		
		text.GetComponent<Text>().color = Color.black;
     }
	 public void outIt()
     {
		this.GetComponent<Animation>().Play();		
		text.GetComponent<Text>().color = Color.white;
     }
}

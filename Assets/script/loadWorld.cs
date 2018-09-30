using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {

	// Use this for initialization
	private Text text1,text2,text3,text4;
	private GameObject world;
	private Canvas canvas;
	void Start () {
		text1 = GameObject.Find("world1Text").GetComponent<Text>();	
		world = GameObject.Find("World1");	
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		SceneManager.LoadScene("MountainLake");
	}
	void OnMouseOver(){
		text1.color = Color.white;
		world.transform.localScale = new Vector3(1f,2.5f,1f);
	}
	void OnMouseExit(){
		text1.color = Color.black;
		world.transform.localScale = new Vector3(1f,1f,1f);
	}
	
}

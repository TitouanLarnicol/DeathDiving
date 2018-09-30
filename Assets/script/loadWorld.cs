using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {

	// Use this for initialization
	private Text text;
	private float zoom;
	private string world;
	private Canvas canvas;
	void Start () {
		switch(this.name){
			case "World1":
			text = GameObject.Find("DesertTitle").GetComponent<Text>();
			world="Desert";
			zoom = 2.5f;
				break;
			case "World2":
			text = GameObject.Find("MountainLakeTitle").GetComponent<Text>();
			world="MountainLake";
			zoom = 0.4f;
				break;
			default:
				break;
		}	
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		SceneManager.LoadScene(world);
	}
	void OnMouseOver(){
		text.color = Color.white;
		this.transform.localScale = new Vector3(1f,zoom,1f);
	}
	void OnMouseExit(){
		text.color = Color.black;
		this.transform.localScale = new Vector3(1f,1f,1f);
	}
	
}

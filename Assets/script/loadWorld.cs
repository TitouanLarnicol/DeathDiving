using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {

	// Use this for initialization
	private Text text;
	private Canvas canvas;
	void Start () {
		text = GameObject.Find("world1Text").GetComponent<Text>();
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		canvas.enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnMouseDown(){
		SceneManager.LoadScene("MainScene");
	}
	void OnMouseOver(){
		canvas.enabled = true;
	}
	void OnMouseExit(){
		canvas.enabled = false;
	}
	
}

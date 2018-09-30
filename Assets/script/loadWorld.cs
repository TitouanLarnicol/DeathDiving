using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {

	// Use this for initialization
	private Text text1,text2,text3,text4;
	private Canvas canvas;
	void Start () {
		text1 = GameObject.Find("world1Text").GetComponent<Text>();		
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		SceneManager.LoadScene("MainScene");
	}
	void OnMouseOver(){
		text1.color = Color.white;
	}
	void OnMouseExit(){
		text1.color = Color.black;
	}
	
}

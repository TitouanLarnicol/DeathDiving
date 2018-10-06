using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playGame : MonoBehaviour{
	// Use this for initialization
	GameObject text;
	public Canvas canvas;
	public Canvas controls;
	void Start () {		
		text = GameObject.Find("playgame");
		controls.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 AnimationClip GetClipByIndex(int index){
     string[] ClipNames = { "backflipLayout", "checkMate", "Tuck"};
     Animation animation = GetComponent<Animation>();
     return animation[ClipNames[index]].clip;
 	}
	 public void onIt()
     {
		this.GetComponent<Animation>().Play();
		text.GetComponent<Text>().color = Color.black;
     }
	 public void outIt()
     {
		
		text.GetComponent<Text>().color = Color.white;
     }
	  public void controlsIn()
     {
		canvas.enabled = false;
		controls.enabled = true;
     }
	 public void backflip()
     {
		 this.GetComponent<Animation>().Play("backflipLayout");
     }
	 public void tuck()
     {
		this.GetComponent<Animation>().Play("Tuck");
     }
	 public void japan()
     {
		this.GetComponent<Animation>().Play("japan");
     }
}

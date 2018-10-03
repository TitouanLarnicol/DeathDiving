using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {	
	// Use this for initialization
	public Text text;
	public Font m_Font;
	public float zoom;
	private Canvas canvas;
	public string world;
	private Font originalFont;
	void Start () {
		originalFont = text.font;
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		SceneManager.LoadScene(world);
	}
	void OnMouseOver(){
		text.color = Color.white;
		text.font = m_Font;
		this.transform.localScale = new Vector3(1f,zoom,1f);
	}
	void OnMouseExit(){
		text.color = Color.black;
		text.font = originalFont;
		this.transform.localScale = new Vector3(1f,1f,1f);
	}
	
}

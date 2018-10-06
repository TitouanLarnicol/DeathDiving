using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class loadMenu : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

	public Animator animator;
	
	void Start () {
		animator = GetComponent<Animator>();
	}
	void Update(){

	}
	// Update is called once per frame
	  public void OnPointerEnter(PointerEventData eventData)
     {
		animator.SetBool("textAnimation",true);
		// Kyle.GetComponent<Animation>().Play();
		
     }
	 public void OnPointerExit(PointerEventData eventData)
     {
		 animator.SetBool("textAnimation",false);
     }
}

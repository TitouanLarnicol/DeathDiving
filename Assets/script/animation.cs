using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K)){
			animator.SetBool("isBackflip",false);
			animator.SetBool("isNormal",true);
			
		}
		if(Input.GetKeyUp(KeyCode.K)){
			animator.SetBool("isBackflip",true);
			animator.SetBool("isNormal",false);
		}
		
		// if(Input.GetKeyUp(KeyCode.K)){
			
		// }
	}
}

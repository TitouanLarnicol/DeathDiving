using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {
	public float moveSpeed;
	public bool onGround;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		moveSpeed = 10f;
		onGround = true;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//Jump
		if(Input.GetButton("Jump")){
			print(transform.rotation);
				rb.velocity = new Vector3(0f,3f,1.5f);				
		}
		//Rotate left
		if(Input.GetKey(KeyCode.G)){
				transform.Rotate(0,0,10f);
		}
		//Rotate Right
		if(Input.GetKey(KeyCode.H)){
				transform.Rotate(0,0,-10f);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(moveSpeed,0,0);			
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(-moveSpeed,0,0);			
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(0,-moveSpeed,0);			
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(0,moveSpeed,0);			
		}
		if(Input.GetKey(KeyCode.W)){
			transform.rotation = Quaternion.Euler (180,0, 0);				
		}
		
		//Move Forward & Backward
		// transform.Translate(0f,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
		
		//Move Left & Right
		// transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,0f);
	}
	void onCollisionEnter(Collision any){
		if(any.gameObject.CompareTag("Ground")){
					onGround = true;
					print("collision");
		}
	
	}

	
}
	
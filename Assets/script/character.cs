		using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {
	public float moveSpeed;
	public int orientation;
	public bool onGround;
	public float inertia;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		moveSpeed = 200f;
		orientation=1;
		onGround=true;
		inertia = moveSpeed;
		rb = GetComponent<Rigidbody>();
		// box.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
				
		if(Input.GetKey(KeyCode.UpArrow) && !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(moveSpeed,0,0);
			rb.AddTorque(transform.right * moveSpeed * Time.deltaTime);			
		}
		if(Input.GetKey(KeyCode.DownArrow)&& !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(- moveSpeed * Time.deltaTime,0,0);	
			inertia+=25;			
		}
		if(Input.GetKey(KeyCode.H) && !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(0,0,-moveSpeed*Time.deltaTime);	
			rb.AddTorque(-transform.forward * moveSpeed * Time.deltaTime);	
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)&& !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(0,-moveSpeed* Time.deltaTime,0);			
		}
		if(Input.GetKey(KeyCode.RightArrow)&& !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			transform.Rotate(0,moveSpeed* Time.deltaTime,0);			
		}
		//Backward Position
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			orientation=1;
			transform.rotation = Quaternion.Euler (0,180, 0);				
		}	
		//Frontward position
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			orientation=-1;
			transform.rotation = Quaternion.Euler (0,0, 0);				
		}	
		//Move Forward & Backward
		// transform.Translate(0f,0f,5f*Input.GetAxis("Vertical")*Time.deltaTime);
		
		//Move Left & Right
		// transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,0f);
	}
	void FixedUpdate(){
		//Jump
		if(Input.GetKeyUp(KeyCode.Space) && onGround){
			rb.constraints = RigidbodyConstraints.None;
			rb.velocity = new Vector3(0f,2*moveSpeed * Time.deltaTime,moveSpeed * Time.deltaTime);		
			onGround=false;		
		}
		if(Input.GetKey(KeyCode.Space)){
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
		}
		if(Input.GetKeyUp(KeyCode.DownArrow) && !onGround){
			// transform.rotation = Quaternion.Euler (90,0, 0);	
			rb.AddTorque(-(transform.right+new Vector3(10f,0,0))*inertia/2 * Time.deltaTime,ForceMode.Acceleration);	
		}
	}
	void OnCollisionEnter(Collision col){
		onGround=true;
		print(transform.rotation);
	}
	bool canJump(){

		return true;
	}

	
}
	
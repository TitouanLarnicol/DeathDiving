		using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {
	public float moveSpeed;
	private int orientation;
	public bool onGround;
	public float inertia;
	private Vector3 initialPosition;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		orientation=0;
		onGround=true;
		inertia =100f;
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionZ;
	}
	
	// Update is called once per frame
	void Update () {
				
		if(Input.GetKey(KeyCode.UpArrow) && !onGround){
			transform.Rotate(moveSpeed * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.DownArrow)&& !onGround){
			transform.Rotate(-moveSpeed * Time.deltaTime,0,0);	
		}
		if(Input.GetKey(KeyCode.H) && !onGround){
			transform.Rotate(0,0,-moveSpeed*Time.deltaTime);	
			// rb.AddTorque(-transform.forward * moveSpeed * Time.deltaTime);	
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)&& !onGround){
			transform.Rotate(0,-moveSpeed* Time.deltaTime,0);			
		}
		if(Input.GetKey(KeyCode.RightArrow)&& !onGround){	
			transform.Rotate(0,moveSpeed* Time.deltaTime,0);			
		}
		//Frontward position
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			if(orientation==0){
				transform.rotation = Quaternion.Euler (0,180, 0);
				orientation=1;
			}
			else{
				transform.rotation = Quaternion.Euler (0,0, 0);
				orientation=0;
			}					
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
			print(inertia);
			rb.AddForce(0,0,30f*inertia* Time.deltaTime);
			rb.velocity = new Vector3(0f,inertia * Time.deltaTime,0);		
			onGround=false;		
		}
		if(Input.GetKey(KeyCode.Space) && onGround){

			rb.constraints = RigidbodyConstraints.FreezePositionZ;
		}
		if(Input.GetKeyUp(KeyCode.DownArrow) && !onGround){
			rb.AddTorque(-(transform.right+new Vector3(10f,0,0))*inertia * Time.deltaTime,ForceMode.Acceleration);	
		}
		if(Input.GetKeyUp(KeyCode.UpArrow) && !onGround){
			rb.AddTorque((transform.right+new Vector3(10f,0,0))*inertia * Time.deltaTime,ForceMode.Acceleration);			
		}
	}
	void OnCollisionEnter(Collision col){
		onGround=true;
		
		// if(transform.rotation.x<0.4f && transform.rotation.x>-0.4f ){
		// 	transform.rotation = Quaternion.Euler (0,0, 0);
		// 	rb.velocity = Vector3.zero;			
		// }

	}

	public void adjustInertia(float newInertia){
		inertia = newInertia;
	}
	public void adjustMoveSpeed(float newSpeed){
		moveSpeed = newSpeed;
		print("moveSpeed");
	}

	
}
	
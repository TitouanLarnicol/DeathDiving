using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour {
	public float moveSpeed,stopInertia,inertia;
	public float  orientation;
	public static character childScript;
	public bool onGround;
	 public Slider impulsionSlider,speedSlider;
	private Vector3 initialPosition;
	private Rigidbody rb;
	public Animator animator;
	// Use this for initialization
	void Awake(){
		childScript = this;
	}
	void Start () {
		impulsionSlider = GameObject.Find("impulsion").GetComponent<Slider>();
		speedSlider = GameObject.Find("rotationSpeed").GetComponent<Slider>();
		initialPosition = transform.position;
		orientation=1f;
		onGround=true;
		adjustInertia(impulsionSlider.value);
		adjustMoveSpeed(speedSlider.value);
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionZ;
		rb.angularDrag = 1;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Frontward position
		
			if(Input.GetKeyDown(KeyCode.K) && !onGround){
			animator.SetBool("isBackflip",false);
			animator.SetBool("isNormal",true);			
		}
		if(Input.GetKeyUp(KeyCode.K) && !onGround){
			animator.SetBool("isBackflip",true);
			animator.SetBool("isNormal",false);
		}
		if(Input.GetKeyDown(KeyCode.J) && !onGround){
			animator.SetBool("goTuck",true);
			animator.SetBool("isTucking",false);
		}
		if(Input.GetKeyUp(KeyCode.J) && !onGround){
			animator.SetBool("goTuck",false);
			animator.SetBool("isTucking",true);
		}
		if(Input.GetKeyDown(KeyCode.X) && !onGround){
			animator.SetBool("goJapan",true);
			animator.SetBool("isJapan",false);
		}
		if(Input.GetKeyUp(KeyCode.X)  && !onGround){
			animator.SetBool("goJapan",false);
			animator.SetBool("isJapan",true);
		}
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			if(orientation==1f){
				transform.rotation = Quaternion.Euler (0,180, 0);
				orientation=-1f;
			}
			else{
				transform.rotation = Quaternion.Euler (0,0, 0);
				orientation=1f;
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
			if(orientation==-1)
				rb.AddForce(0,0,-500*transform.rotation.x * inertia*Time.deltaTime,ForceMode.Impulse);
			print(transform.rotation.x );
			rb.constraints = RigidbodyConstraints.None;
			rb.AddForce(0,0,5*transform.rotation.x * inertia*Time.deltaTime,ForceMode.Impulse);
			rb.velocity = new Vector3(0f,inertia * Time.deltaTime,0);		
			onGround=false;		
		}
		if(Input.GetKey(KeyCode.Space) && onGround){
			print(orientation);
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
		}
		if(Input.GetKey(KeyCode.DownArrow)&& !onGround){
			rb.AddTorque(-transform.right*moveSpeed*Time.deltaTime,ForceMode.Impulse);
		}
		if(Input.GetKey(KeyCode.UpArrow) && !onGround){
			rb.AddTorque(transform.right*moveSpeed * Time.deltaTime,ForceMode.Impulse);
		}
		if(Input.GetKey(KeyCode.H) && !onGround){
			rb.AddTorque(-transform.forward*moveSpeed * Time.deltaTime,ForceMode.Impulse);	
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)&& !onGround){
			rb.AddTorque(-transform.up*moveSpeed * Time.deltaTime,ForceMode.Impulse);			
		}
		if(Input.GetKey(KeyCode.RightArrow)&& !onGround){	
			rb.AddTorque(transform.up*moveSpeed * Time.deltaTime,ForceMode.Impulse);			
		}
	}
	void OnCollisionEnter(Collision col){
		onGround=true;
		
		if(transform.rotation.x<0.4f && transform.rotation.x>-0.4f ){
			// transform.rotation = Quaternion.Euler (0,0, 0);
			// rb.velocity = Vector3.zero;	
			print("you won");		
		}
		else{
			print("you lose");
		}

	}

	public void adjustInertia(float newInertia){
		inertia = newInertia;
	}
	public void adjustMoveSpeed(float newSpeed){
		moveSpeed = newSpeed;
		print("moveSpeed");
	}
}
	
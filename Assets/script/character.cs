using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour {
	public float moveSpeed,inertia,impulsion,xOrigin,orientation;
	public static character childScript;
	public bool onGround;
	private Rigidbody rb;
	Scene scene;
	public Animator animator;
	// Use this for initialization
	void Awake(){
		childScript = this;
	}
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		scene = SceneManager.GetActiveScene();
		orientation=1f;
		onGround=true;
		moveSpeed = 500f;
		adjustInertia(300f);
		adjustImpulsion(300f);
		rb.constraints = RigidbodyConstraints.FreezePositionZ;
		rb.angularDrag = 0.85f;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Frontward position
		
		if(Input.GetKeyDown(KeyCode.K) && !onGround){
			rb.maxAngularVelocity = 6f;
			animator.SetBool("isBackflip",false);
			animator.SetBool("isNormal",true);			
		}
		if(Input.GetKeyUp(KeyCode.K)){
			animator.SetBool("isBackflip",true);
			animator.SetBool("isNormal",false);
		}
		if(Input.GetKeyDown(KeyCode.J) && !onGround){
			rb.maxAngularVelocity = 8f;
			animator.SetBool("goTuck",true);
			animator.SetBool("isTucking",false);
		}
		if(Input.GetKeyUp(KeyCode.J)){	
			rb.maxAngularVelocity = 7f;		
			animator.SetBool("goTuck",false);
			animator.SetBool("isTucking",true);
		}
		if(Input.GetKeyDown(KeyCode.X) && !onGround){
			animator.SetBool("goJapan",true);
			animator.SetBool("isJapan",false);
		}
		if(Input.GetKeyUp(KeyCode.X)){
			animator.SetBool("goJapan",false);
			animator.SetBool("isJapan",true);
		}
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			if(orientation==1f){
				if(scene.name=="MountainLake"){
				transform.rotation = Quaternion.Euler(0,0,0);
				}
				else{
					transform.rotation = Quaternion.Euler (0,180, 0);
				}
				orientation=-1f;
			}
			else{
				if(scene.name=="MountainLake"){
				transform.rotation = Quaternion.Euler (0,180,0);
				}
				else{
					transform.rotation = Quaternion.Euler (0,0, 0);
				}
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
			if(orientation==-1){
				rb.AddRelativeForce(0,impulsion * Time.deltaTime,0,ForceMode.Impulse);
				rb.AddRelativeForce(0,0,-inertia*Time.deltaTime,ForceMode.Impulse);
			}
			else{
				print(impulsion);
				rb.AddRelativeForce(0,impulsion * Time.deltaTime,0,ForceMode.Impulse);
				rb.AddRelativeForce(0,0,inertia*Time.deltaTime,ForceMode.Impulse);
			}
			rb.constraints = RigidbodyConstraints.None;
			onGround=false;		
		}
		if(Input.GetKey(KeyCode.Space) && onGround){
			impulsion*=1.02f;
			inertia*=1.01f;
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
		if(Input.GetKey(KeyCode.G) && !onGround){
			rb.AddTorque(transform.forward*moveSpeed * Time.deltaTime,ForceMode.Impulse);	
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
		adjustImpulsion(300f);
		adjustInertia(300f);
	}

	public void adjustInertia(float newInertia){
		inertia = newInertia;
	}
	public void adjustImpulsion(float newImpulsion){
		if(scene.name == "MountainLake"){
			impulsion = newImpulsion + 150f;
		}
		else
			impulsion = newImpulsion;
	}
}
	
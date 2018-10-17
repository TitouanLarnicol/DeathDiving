using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterFreeWorld : MonoBehaviour {

	public float moveSpeed,inertia,impulsion,orientation;
	public bool onGround;
	private Rigidbody rb;
	Scene scene;
	public Animator animator;
	public AudioSource sourceScream;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		animator.SetBool("isImpulsion",true);
		animator.SetBool("isMute",true);
		animator.SetBool("isSafety",true);
		orientation=1f;
		onGround=true;
		moveSpeed = 500f;
		rb.constraints = RigidbodyConstraints.FreezePositionZ;
		rb.angularDrag = 0.85f;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Frontward position
		
		if(Input.GetKeyDown(KeyCode.K) && !onGround){
			rb.maxAngularVelocity = 6f;
			sourceScream.Play();
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
		if(Input.GetKeyDown(KeyCode.W)  && !onGround ){
			animator.SetBool("isMute",false);
		}
		if(Input.GetKeyUp(KeyCode.W)){
			animator.SetBool("isMute",true);
		}
		if(Input.GetKeyDown(KeyCode.S)  && !onGround ){
		animator.SetBool("isSafety",false);
		}
		if(Input.GetKeyUp(KeyCode.S)){
			animator.SetBool("isSafety",true);
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
	}
	void FixedUpdate(){
		//Jump
		if(Input.GetKeyUp(KeyCode.Space) && onGround){
			animator.SetBool("isImpulsion",true);
			rb.constraints = RigidbodyConstraints.None;
			onGround=false;	
			if(orientation==-1){
				rb.AddRelativeForce(0,impulsion * Time.deltaTime,0,ForceMode.Impulse);
				rb.AddRelativeForce(0,0,-inertia*Time.deltaTime,ForceMode.Impulse);
			}
			else{
				rb.AddRelativeForce(0,impulsion * Time.deltaTime,0,ForceMode.Impulse);
				rb.AddRelativeForce(0,0,inertia*Time.deltaTime,ForceMode.Impulse);
			}
				
		}
		if(Input.GetKeyDown(KeyCode.Space) && onGround){
			animator.SetBool("isImpulsion",false);
		}
		
		if(Input.GetKey(KeyCode.Space) && onGround){
			impulsion*=1.02f;
			inertia*=1.01f;
			rb.constraints = RigidbodyConstraints.FreezePositionZ;
		}
		if(Input.GetKey(KeyCode.DownArrow)&& !onGround){
			rb.AddTorque(-transform.right*moveSpeed*Time.deltaTime,ForceMode.Acceleration);
		}
		if(Input.GetKey(KeyCode.UpArrow) && !onGround){
			rb.AddTorque(transform.right*moveSpeed * Time.deltaTime,ForceMode.Acceleration);
		}
		if(Input.GetKey(KeyCode.H) && !onGround){
			rb.AddTorque(-transform.forward*moveSpeed * Time.deltaTime,ForceMode.Acceleration);	
		}
		if(Input.GetKey(KeyCode.G) && !onGround){
			rb.AddTorque(transform.forward*moveSpeed * Time.deltaTime,ForceMode.Acceleration);	
		}
		if(Input.GetKey(KeyCode.LeftArrow)&& !onGround){
			rb.AddTorque(-transform.up*moveSpeed * Time.deltaTime,ForceMode.Acceleration);			
		}
		if(Input.GetKey(KeyCode.RightArrow)&& !onGround){	
			rb.AddTorque(transform.up*moveSpeed * Time.deltaTime,ForceMode.Acceleration);			
		}
		//Move on ground
		if(Input.GetKey(KeyCode.DownArrow)&& onGround){
			transform.Translate(new Vector3(0,0,-5f*Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.UpArrow)&& onGround){
			transform.Translate(new Vector3(0,0,5f*Time.deltaTime));
		}
	}
	void OnCollisionEnter(Collision col){
		onGround=true;
		adjustImpulsion(400f);
		adjustInertia(400f);
	}

	public void adjustInertia(float newInertia){
		inertia = newInertia;
	}
	public void adjustImpulsion(float newImpulsion){
		impulsion = newImpulsion + 150f;
	}
}
	

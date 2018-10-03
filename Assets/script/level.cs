using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour {
	ArrayList levelPosition = new ArrayList();
	private bool alreadyTrigger;
	private Rigidbody rb;
	private IEnumerator coroutine;
	Transform parent;
	Vector3 diffParentChild;
	public int stage,levelLanding;
	private Scene scene;
	public GameObject instanceScript;
	character characterInstance;
	// Use this for initialization
	void Start () {
		levelLanding=0;
		characterInstance = instanceScript.GetComponent<character>();
		setScene(); 
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name =="Position0" || col.gameObject.name =="Position1" || col.gameObject.name =="Position2"){
				alreadyTrigger = false;
		}
		else{
			coroutine = waitForRespawn(1.2f,col);
			StartCoroutine(coroutine);
		}						
	}
	 private IEnumerator waitForRespawn(float waitTime,Collision col)
    {
		rb.angularDrag = 1000;
        yield return new WaitForSeconds(waitTime);
		if(col.gameObject.name == "landingPlane" && alreadyTrigger==false){
				if(stage<2){
					stage++;
					setOrientation();
					alreadyTrigger = true;
				}
				else{
					if(stage == 2 && levelLanding !=2){
						stage = 0;
						levelLanding++;
						setOrientation();
					alreadyTrigger = true;
					}
				}
		}
		else{
			if(col.gameObject.name == "waterLanding" && alreadyTrigger == false){
				setOrientation();
				alreadyTrigger = true;
			}
		}		
		rb.drag = 0;
		rb.angularDrag = 1;
    }

	void setOrientation(){
			if(scene.name=="MountainLake"){
					transform.rotation = Quaternion.Euler (0,180, 0);
				}
			else{
				transform.rotation = Quaternion.Euler (0,0, 0);
			}
			//Re attach parent & child with right position
			parent.rotation = transform.rotation;
			transform.position = (Vector3) levelPosition[stage];
			characterInstance.orientation = 1;	
			rb.velocity = Vector3.zero;
			parent.position = transform.position;
			transform.SetParent(parent);
	}
	void setScene(){
		levelLanding = 0;
		stage = 0;
		alreadyTrigger = false;
		scene = SceneManager.GetActiveScene();
		parent = transform.parent;
		diffParentChild = transform.position - parent.position;
		levelPosition.Add(GameObject.Find("Position0").transform.position);
		levelPosition.Add(GameObject.Find("Position1").transform.position);
		levelPosition.Add(GameObject.Find("Position2").transform.position);
		rb = GetComponent<Rigidbody>();
	}
}

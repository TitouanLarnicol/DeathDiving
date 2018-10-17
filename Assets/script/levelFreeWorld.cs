using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelFreeWorld : MonoBehaviour {
	private Rigidbody rb;
	private IEnumerator coroutine;
	Transform parent;
	Vector3 diffParentChild;
	private Scene scene;
	// Use this for initialization
	void Start () {
		setScene(); 
	}

    void FixedUpdate(){
        if(Input.GetKeyDown(KeyCode.R)){
			setOrientation();
		}
    }
	void OnCollisionEnter(Collision col){
        coroutine = waitForRespawn(1.2f,col);
        StartCoroutine(coroutine);						
	}
	 private IEnumerator waitForRespawn(float waitTime,Collision col)
    {
		rb.angularDrag = 1000;
        yield return new WaitForSeconds(waitTime);
        if(!col.gameObject.name.Equals("PositionCharacter")){
            setOrientation();
        }
		rb.drag = 0;
		rb.angularDrag = 1;
    }
	void setOrientation(){
			transform.rotation = Quaternion.Euler (0,0, 0);
			//Re attach parent & child with right position
			parent.rotation = transform.rotation;
			transform.position = GameObject.Find("PositionCharacter").transform.position;	
			rb.velocity = Vector3.zero;
			parent.position = transform.position;
			transform.SetParent(parent);
	}
	void setScene(){
		parent = transform.parent;
		diffParentChild = transform.position - parent.position;
		rb = GetComponent<Rigidbody>();
	}
}

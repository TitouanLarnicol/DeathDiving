using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
	ArrayList levelPosition = new ArrayList();
	private Rigidbody rb;
	private IEnumerator coroutine;
	Transform parent;
	Vector3 diffParentChild;
	private int levelNumber;
	// Use this for initialization
	void Start () {
		levelNumber = 0;
		parent = transform.parent;
		diffParentChild = transform.position - parent.position;
		levelPosition.Add(GameObject.Find("Position1").transform.position);
		levelPosition.Add(GameObject.Find("Position2").transform.position);
		//transform.position = (Vector3) levelPosition[0];
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		coroutine = waitForRespawn(1.2f,col);
		StartCoroutine(coroutine);
						
	}
	 private IEnumerator waitForRespawn(float waitTime,Collision col)
    {
		
		rb.angularDrag = 1000;
        yield return new WaitForSeconds(waitTime);
		if(col.gameObject.name == "waterLanding"){
			if(levelNumber<2){
				print("on passe au if");
				transform.position = (Vector3) levelPosition[levelNumber];
				transform.rotation = Quaternion.Euler (0,0, 0);
				rb.velocity = Vector3.zero;
				parent.position = transform.position;
				parent.rotation = transform.rotation;
				transform.SetParent(parent);
				levelNumber++;
			}
		}
		else{
			if(col.gameObject.name =="Plateform1" || col.gameObject.name =="Plateform2" || col.gameObject.name =="Plateform3"){
				// rb.velocity = Vector3.zero;	
				rb.constraints = RigidbodyConstraints.FreezePositionZ;	
				parent.position = transform.position - diffParentChild;
				parent.rotation = Quaternion.Euler (0,0, 0);
				transform.SetParent(parent);
			}
		}
		rb.drag = 0;
		rb.angularDrag = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
	ArrayList levelPosition = new ArrayList();
	private Rigidbody rb;
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
		
		if(col.gameObject.name == "Landing"){
			if(levelNumber<2){
				transform.position = (Vector3) levelPosition[levelNumber];
				parent.position = transform.position;
				parent.rotation = transform.rotation;
				transform.SetParent(parent);
				levelNumber++;
			}
		}
		else{
			if(col.gameObject.name =="Plateform1" || col.gameObject.name =="Plateform2" || col.gameObject.name =="Plateform3"){
				transform.rotation = Quaternion.Euler (0,0, 0);
				rb.velocity = Vector3.zero;	
				rb.constraints = RigidbodyConstraints.FreezePositionZ;	
				parent.position = transform.position - diffParentChild;
				parent.rotation = transform.rotation;
				transform.SetParent(parent);
			}
		}	
		
			
	}
}

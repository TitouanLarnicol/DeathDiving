using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
	ArrayList levelPosition = new ArrayList();
	private Rigidbody rb;
	Transform parent;
	private int levelNumber;
	// Use this for initialization
	void Start () {
		levelNumber = 0;
		parent = transform.parent;
		print(parent.name);
		levelPosition.Add(GameObject.Find("Position0").transform.position);
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
			parent.position = transform.position;
			transform.SetParent(parent);
			if(levelNumber<2){
				parent.position = (Vector3) levelPosition[levelNumber];
				levelNumber++;
			}
		}
		
	}
}

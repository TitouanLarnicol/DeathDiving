using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelControl : MonoBehaviour {

	public static levelControl Instance;
	public static bool[] levelArray = new bool[4] {true,false,false,false};
	public int speed = 10;
	void displayArray(){
		foreach(bool value in levelArray)
			print(value);
	}	
    void Awake ()   
       {
			
		   	if(SceneManager.GetActiveScene().name=="chooseWorld"){
			for (int i =0; i<=3;i++){
				if(levelArray[i]==true){
					GameObject.Find("lock"+i).SetActive(false);
					GameObject.Find("World"+i).GetComponent<BoxCollider>().enabled = true;
				}
				else{
					GameObject.Find("lock"+i).SetActive(true);
					GameObject.Find("World"+i).GetComponent<BoxCollider>().enabled = false;
				}
			}
		}
		displayArray();
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
	void update(){
	}
}

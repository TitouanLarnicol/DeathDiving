 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMusic : MonoBehaviour{
    static bool AudioBegin = false; 
    public AudioSource source;
    Scene scene;
    void Start(){
       source = GetComponent<AudioSource>();
       print(source);
    }
    void Awake(){
        if (!AudioBegin) {
        source.Play ();
        DontDestroyOnLoad (gameObject);
        AudioBegin = true;
        } 
        }
    void Update () {
        print(scene.name);
         scene = SceneManager.GetActiveScene();
        if(!scene.name.Equals("chooseWorld")  &&  !scene.name.Equals("Menu"))
        {
            source.Stop();
            AudioBegin = false;
        }
    }
}
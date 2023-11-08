using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] Vector3 spawnPos;
    
    private void Awake() {
        spawnPos=this.transform.position;
    }
    void Start(){
       
       
    }
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag){
            case "Obstacle":
                // Debug.Log("obstacle");
                // this.transform.position=spawnPos;
                // Quaternion rote=Quaternion.Euler(0,0,0);
                // this.transform.rotation=rote;
                // this.gameObject.GetComponent<Movement>().GetComponent<Rigidbody>().isKinematic=true;
                // this.gameObject.GetComponent<Movement>().GetComponent<Rigidbody>().isKinematic=false;
            ReloadScene();
                break;
            case "finish":
                LoadNextLevel();
                break;
            default :
                break;

        }
    }
    void ReloadScene(){
        int currentSceneIndex =SceneManager.GetActiveScene().buildIndex;
        //GetActiveScene(): Hàm này trả về Scene hiện tại mà người chơi đang chơi trong game
        //buildIndex:  trả về chỉ số (index) của Scene 
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel(){
         int currentSceneIndex =SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex=currentSceneIndex+1;
        if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
            nextSceneIndex=0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

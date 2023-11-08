using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float thrust;
    [SerializeField] float speedRotate;
    AudioSource audi;
    Rigidbody rigi;
    void Start()
    {
        rigi=GetComponent<Rigidbody>();
        audi=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("loi roi");
        
        ProcessRotation();
        ProcessThrust();
    }
    private void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rigi.AddRelativeForce(Vector3.up* thrust*Time.deltaTime);
            if(!audi.isPlaying){
                audi.Play();
            }
            
        }else
            audi.Stop();
    }
    private void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
          ApplyRotation(speedRotate);
        }
        else if(Input.GetKey(KeyCode.D)){
          ApplyRotation(-speedRotate);
            
        }
    }
    private void ApplyRotation(float SpeedRotate){
         rigi.freezeRotation=true;
        this.transform.Rotate(Vector3.forward*SpeedRotate*Time.deltaTime);
        rigi.freezeRotation=false;

    }
}

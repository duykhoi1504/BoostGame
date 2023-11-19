using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period=2f;
    void Start()
    {
        startPos=this.transform.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Epsilon );
        if(period<=Mathf.Epsilon) return;
        ///////////////////////////   
        float cycles=Time.time/period;
        float tau=Mathf.PI*2;
        float rawSinWave=Mathf.Sin(cycles*tau); 
        movementFactor=(rawSinWave+1f)/2f;
        ///////////////////////////////
       Vector3 offset=movementFactor*movementVector;
       this.transform.position=startPos+offset;
    }
}

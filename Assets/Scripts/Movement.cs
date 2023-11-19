using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float thrust;
    [SerializeField] [Range(0,200)]float speedRotate;
    AudioSource audi;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEnginePa;
    [SerializeField] ParticleSystem rightEnginePa;

    [SerializeField] ParticleSystem leftEnginePa;

    Rigidbody rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        audi = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("loi roi");

        ProcessRotation();
        ProcessThrust();
    }
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

     private void StartThrust()
    {
        rigi.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!audi.isPlaying)
        {
            audi.PlayOneShot(mainEngine);
        }
        if (!mainEnginePa.isPlaying)
            mainEnginePa.Play();
    }

    private void StopThrust()
    {
        audi.Stop();
        mainEnginePa.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RightRotate();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LeftRotate();
        }
        else
        {
            StopRotate();

        }
    }

    private void StopRotate()
    {
        rightEnginePa.Stop();
        leftEnginePa.Stop();
    }

    private void LeftRotate()
    {
        ApplyRotation(-speedRotate);

        if (!leftEnginePa.isPlaying)
            leftEnginePa.Play();
    }

    private void RightRotate()
    {
        ApplyRotation(speedRotate);
        if (!rightEnginePa.isPlaying)
            rightEnginePa.Play();
    }

    private void ApplyRotation(float SpeedRotate)
    {
        rigi.freezeRotation = true;
        this.transform.Rotate(Vector3.forward * SpeedRotate * Time.deltaTime);
        rigi.freezeRotation = false;

    }
}

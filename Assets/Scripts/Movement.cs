using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float thrust;
    [SerializeField] float speedRotate;
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
            rigi.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audi.isPlaying)
            {
                audi.PlayOneShot(mainEngine);
            }
            if (!mainEnginePa.isPlaying)
                mainEnginePa.Play();
        }
        else
        {
            audi.Stop();
            mainEnginePa.Stop();

        }
    }
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(speedRotate);
            if (!rightEnginePa.isPlaying)
                rightEnginePa.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-speedRotate);

            if (!leftEnginePa.isPlaying)
                leftEnginePa.Play();
        }
        else
        {
            rightEnginePa.Stop();
            leftEnginePa.Stop();

        }
    }
    private void ApplyRotation(float SpeedRotate)
    {
        rigi.freezeRotation = true;
        this.transform.Rotate(Vector3.forward * SpeedRotate * Time.deltaTime);
        rigi.freezeRotation = false;

    }
}

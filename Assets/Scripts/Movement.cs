using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    public float thrustValue = 100f;
    public float rotationThrustValue = 100f;
    public AudioClip mainEngine;
    AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }

   
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
       
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("Thrusters Active");
            rb.AddRelativeForce(Vector3.up * thrustValue * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }

        else
        {
            audioSource.Stop();

        }
    
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrustValue);

        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrustValue);

        }



    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;    
    }
}

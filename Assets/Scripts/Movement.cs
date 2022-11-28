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
    public ParticleSystem thrustFX;
    bool leftButtonPressed = false;
    bool rightButtonPressed = false;
    bool isThrustPressed = false;


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
        if (Input.GetKey(KeyCode.Space)|| isThrustPressed)
        {
            StartThrusting();
        }


        else
        {
            StopThrusting();

        }

    }

    private void StopThrusting()
    {
        audioSource.Stop();
        thrustFX.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustValue * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!thrustFX.isPlaying)
        {
            thrustFX.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)||leftButtonPressed)
        {
            ApplyRotation(rotationThrustValue);

        }

        else if (Input.GetKey(KeyCode.D)||rightButtonPressed)
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
   /* public void RightButton()
    {
         ApplyRotation(-rotationThrustValue);
    }*/
    public void LeftButtonPressed()
    {

        leftButtonPressed = true;
    }
    public void LeftButtonReleased()
    {

        leftButtonPressed = false;
    }

    public void RightButtonPressed()
    {

        rightButtonPressed = true;
    }
    public void RightButtonReleased()
    {

        rightButtonPressed = false;
    }

    public void ThrustButtonPressed()
    {
        isThrustPressed = true;
    }
    public void ThrustButtonReleased()
    {
        isThrustPressed = false;
    }


}

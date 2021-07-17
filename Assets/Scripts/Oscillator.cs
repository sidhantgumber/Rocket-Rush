using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    public Vector3 movementVector;
    float movementFactor;

    public float timePeriod=2f; // ek oscillation mei kitni der
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePeriod == 0) { return; }            // To protect against NaN error, dividing by zero error, instead of time pd == 0  we should use time period <= mathf.Epsilon as epsilon is the smallest number recognised by unity 
        float cycles = Time.time / timePeriod;      // toal complete oscillations
        float tau = Mathf.PI * 2;                   // represents 2pie
        float sinWave = Mathf.Sin(cycles * tau);    // returns a value between -1 and 1 corresponing to the pos of asteroid in the cycle
                                                    // this value gradually increases with every frame, staring from -1 it goes to + 1 then back to -1 thereby completing a full oscillation
        movementFactor = (sinWave + 1f) / 2f;       // movement factor had to be between 0 and 1 because nahi to movement vector ki value exceed ho jaati orignal value se
                                                             // 
        Vector3 offSet = movementVector * movementFactor;
        transform.position = startingPos + offSet;   // here the starting position of the object is a constant, usme offset add ho raha hai, when the movement factor is increasing movement right mei hogi, when it is decreasing movement left mei hogi, because starting pos mei off set add kar rahe hain
        
    }
}

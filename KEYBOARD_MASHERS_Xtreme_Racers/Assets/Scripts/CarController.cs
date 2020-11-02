// RigidBody 2D settings:
// Body Type: Dynamic
// Mass: 1
// Linear Drag: 2
// Angular Drag: 1
// Gravity Scale: 0



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //public float maxSpeed;
    public float acceleration=25f;
    public float steeringPower=200f;
    public float driftFactor_Stick=0.9f;
    //public float driftFactor_Slip;
    //public float maxStickVelocity;
    //public float minSlipVelocity;


    float steering, speed, direction;
    
    private Rigidbody2D rb;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log('start');

    }
 

    private void FixedUpdate() {
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log(rightVelocity().magnitude);

        float driftFactor = driftFactor_Stick;
       

        rb.velocity = forwardVelocity() + rightVelocity() * driftFactor;

        rb.AddForce(transform.up * v * acceleration);
        // go forward

        float t = Mathf.Lerp(0, steeringPower, rb.velocity.magnitude/5);
        // if speed is below 5 than steering power will drop to 0
        
        rb.angularVelocity = h * t;
        // turning
    }

    Vector2 forwardVelocity(){
        // Return only the forward direction. 
        // Reset sideway velocity
        // dot product of two vectors
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 rightVelocity(){
        // dot product of two vectors
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }


}
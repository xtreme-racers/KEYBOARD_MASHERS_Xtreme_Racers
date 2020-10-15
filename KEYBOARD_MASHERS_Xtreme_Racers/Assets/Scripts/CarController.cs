// TODO:
//     - Tweak car deacceleration when down arraow key is pressed
//     - Tweak values to make acceleration more responsive
//     - Current Setting: Max Speed = 20
//                        acceleration = 10
//                        deacceleration = 10
//                        steering = 3


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float deacceleration;
    public float steering;
    
    private Rigidbody2D rb;
    private float currentSpeed;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log('start');

    }
 
    void FixedUpdate () {
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 speed;
        
        if(v>0){
            // pressing up key
            speed = transform.up * (v * acceleration);
        }else if(v<0){
            // pressing down key
            speed = transform.up * (v * deacceleration);
        }else{
            // release all keys
            speed = Vector2.zero;
        }
        

        // if(speed != Vector2.zero){
        //     rb.AddForce(speed);
        // }else{
        //     Debug.Log("here");
        //     rb.AddForce(-speed);

        // }

        rb.AddForce(speed);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if(direction >= 0.0f) {
            rb.rotation += h * steering * (rb.velocity.magnitude / 5.0f);
        } else {
            rb.rotation -= h * steering * (rb.velocity.magnitude / 5.0f);
        }

        Vector2 forward = new Vector2(0.0f, 0.5f);
        float steeringRightAngle;
        if(rb.angularVelocity > 0) {
            steeringRightAngle = -90;
        } else {
            steeringRightAngle = 90;
        }

        Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
        Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

        Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);

        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if (rb.velocity.magnitude > maxSpeed){
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        currentSpeed = rb.velocity.magnitude;

        //Debug.Log(speed);
    }
}
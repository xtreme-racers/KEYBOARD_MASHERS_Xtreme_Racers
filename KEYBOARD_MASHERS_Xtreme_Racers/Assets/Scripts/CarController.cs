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
    public float acceleration = 25f;
    public float steeringPower = 200f;
    public float driftFactor_Stick = 0.9f;

    public float boostAcceleration = 50f;
    public float boostSecond = 1f; // in seconds

    public float trapAcceleration = 5f;
    public float trapSecond = 1f;

    private float boostTimer, trapTimer, normalAcceleration;
    private bool isBoost = false;
    private bool isTrap = false;
    private Rigidbody2D rb;

    public GameObject bullet;

    void Awake()
    {
        Nitro.onNitro += onBoost;
        Trap.onTrap += onSetBack;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log('start');
        boostTimer = boostSecond;
        trapTimer = trapSecond;
        normalAcceleration = acceleration;
    }


    private void Update()
    {
        if (isBoost)
        { // boost
            if (boostTimer > 0)
            {
                boostTimer -= Time.deltaTime;
                acceleration = boostAcceleration;
            }
            else
            {
                isBoost = false;
                acceleration = normalAcceleration; //reset to normal
                boostTimer = boostSecond;
            }
        }

        if (isTrap)
        { // trap
            if (trapTimer > 0)
            {
                trapTimer -= Time.deltaTime;
                acceleration = trapAcceleration;
            }
            else
            {
                isTrap = false;
                acceleration = normalAcceleration; //reset to normal
                trapTimer = trapSecond;
            }
        }
    }

    private void FixedUpdate()
    {
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Debug.Log(rightVelocity().magnitude);

        float driftFactor = driftFactor_Stick;


        rb.velocity = forwardVelocity() + rightVelocity() * driftFactor;

        rb.AddForce(transform.up * v * acceleration);
        // go forward

        float t = Mathf.Lerp(0, steeringPower, rb.velocity.magnitude / 5);
        // if speed is below 5 than steering power will drop to 0

        rb.angularVelocity = h * t;
        // turning
    }

    Vector2 forwardVelocity()
    {
        // Return only the forward direction. 
        // Reset sideway velocity
        // dot product of two vectors
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

    Vector2 rightVelocity()
    {
        // dot product of two vectors
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }


    void onBoost()
    {
        // When hit the nitro collider, speed boost for n seconds
        isBoost = true;
    }

    void onSetBack()
    {
        isTrap = true;
    }

    public void shootBullet()
    {
        while (true)
        {
            GameObject laser = Instantiate(bullet) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
        }
    }
    private void Fire()
    {
        if (Input.GetKeyDown("space"))
        {
            shootBullet();
        }
    }
}
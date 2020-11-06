using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float maxSpeed;
    public float acceleration;
    public float steering;
 
    private Rigidbody2D car;
    private float currentSpeed;
 

    // Start is called before the first frame update
    void Start()
    {
        this.car = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add movement controll
    }
}

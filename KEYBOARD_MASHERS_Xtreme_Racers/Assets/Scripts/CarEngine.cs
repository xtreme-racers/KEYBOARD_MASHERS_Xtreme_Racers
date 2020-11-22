using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarEngine : MonoBehaviour
{

    public Transform path;
    public float maxSteerAngle = 45f;
    public float turnSpeed = 5f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxMotorTorque = 80f;
    public float maxBrakeTorque = 150f;
    public float currentSpeed;
    public float maxSpeed = 100f;
    public Vector3 centerOfMass;
    public bool isBraking = false;
    public Texture2D textureNormal;
    public Texture2D textureBraking;
    public Renderer carRenderer;

    [Header("Sensors")]
    public float sensorLength = 3f;
    public Vector3 frontSensorPosition = new Vector3(0f, 0.2f, 0.5f);
    public float frontSideSensorPosition = 0.2f;
    public float frontSensorAngle = 30f;

    private List<Transform> nodes;
    private int currentNode = 0;
    private bool avoiding = false;
    private float targetSteerAngle = 0;

    private void Start()
    {
        GetComponent<Rigidbody2D>().centerOfMass = this.centerOfMass;
        Transform[] pathTransforms = this.path.GetComponentsInChildren<Transform>();
        this.nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != this.path.transform)
            {
                this.nodes.Add(pathTransforms[i]);
            }
        }
    }

    private void FixedUpdate()
    {
        Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
        LerpToSteerAngle();
    }

    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos += transform.forward * this.frontSensorPosition.z;
        sensorStartPos += transform.up * this.frontSensorPosition.y;
        float avoidMultiplier = 0;
        this.avoiding = false;

        //front right sensor
        sensorStartPos += transform.right * this.frontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, this.sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                this.avoiding = true;
                avoidMultiplier -= 1f;
            }
        }

        //front right angle sensor
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(this.frontSensorAngle, transform.up) * transform.forward, out hit, this.sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                this.avoiding = true;
                avoidMultiplier -= 0.5f;
            }
        }

        //front left sensor
        sensorStartPos -= transform.right * this.frontSideSensorPosition * 2;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, this.sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                this.avoiding = true;
                avoidMultiplier += 1f;
            }
        }

        //front left angle sensor
        else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-this.frontSensorAngle, transform.up) * transform.forward, out hit, this.sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                avoiding = true;
                avoidMultiplier += 0.5f;
            }
        }

        //front center sensor
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartPos, transform.forward, out hit, this.sensorLength))
            {
                if (!hit.collider.CompareTag("Terrain"))
                {
                    Debug.DrawLine(sensorStartPos, hit.point);
                    this.avoiding = true;
                    if (hit.normal.x < 0)
                    {
                        avoidMultiplier = -1;
                    }
                    else
                    {
                        avoidMultiplier = 1;
                    }
                }
            }
        }

        if (this.avoiding)
        {
            this.targetSteerAngle = this.maxSteerAngle * avoidMultiplier;
        }

    }

    private void ApplySteer()
    {
        if (this.avoiding) return;
        Vector3 relativeVector = this.path.InverseTransformPoint(this.nodes[this.currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * this.maxSteerAngle;
        this.targetSteerAngle = newSteer;
    }

    private void Drive()
    {
        this.currentSpeed = 2 * Mathf.PI * this.wheelFL.radius * this.wheelFL.rpm * 60 / 1000;

        if (this.currentSpeed < maxSpeed && !this.isBraking)
        {
            this.wheelFL.motorTorque = this.maxMotorTorque;
            this.wheelFR.motorTorque = this.maxMotorTorque;
        }
        else
        {
            this.wheelFL.motorTorque = 0;
            this.wheelFR.motorTorque = 0;
        }
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, this.nodes[this.currentNode].position) < 1f)
        {
            if (this.currentNode == this.nodes.Count - 1)
            {
                this.currentNode = 0;
            }
            else
            {
                this.currentNode++;
            }
        }
    }

    private void Braking()
    {
        if (this.isBraking)
        {
            this.carRenderer.material.mainTexture = this.textureBraking;
            this.wheelRL.brakeTorque = this.maxBrakeTorque;
            this.wheelRR.brakeTorque = this.maxBrakeTorque;
        }
        else
        {
            this.carRenderer.material.mainTexture = this.textureNormal;
            this.wheelRL.brakeTorque = 0;
            this.wheelRR.brakeTorque = 0;
        }
    }
    private void LerpToSteerAngle()
    {
        this.wheelFL.steerAngle = Mathf.Lerp(this.wheelFL.steerAngle, this.targetSteerAngle, Time.deltaTime * this.turnSpeed);
        this.wheelFR.steerAngle = Mathf.Lerp(this.wheelFR.steerAngle, this.targetSteerAngle, Time.deltaTime * this.turnSpeed);
    }
}

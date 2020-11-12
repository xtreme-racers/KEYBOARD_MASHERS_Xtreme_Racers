using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCheckpoint : MonoBehaviour
{

    public int index;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CarLap>())
        {
            CarLap Car = other.GetComponent<CarLap>();
            if (Car.CheckpointIndex == index + 1 || Car.CheckpointIndex == index - 1)
            { 
                Car.CheckpointIndex = index;
                Debug.Log(index);
            }
        }
    }
}

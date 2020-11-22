using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapHandle : MonoBehaviour
{
    public int CheckpointAmt;
    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.GetComponent<CarLap>())
        {
            CarLap Car = other.GetComponent<CarLap>();
            if (Car.CheckpointIndex == CheckpointAmt)
            {
                Car.CheckpointIndex = 0;
                Car.lapNumber++;

                Debug.Log(Car.lapNumber);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LapCounter : MonoBehaviour
{
    public static LapCounter instance; //Our singleton
    public TextMeshProUGUI LapText;
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.GetComponent<CarLap>())
        {
            CarLap Car = other.GetComponent<CarLap>();
            LapText.text = Car.lapNumber + "";
            if (Car.lapNumber == 3)
            {

            }
        }
    }
}
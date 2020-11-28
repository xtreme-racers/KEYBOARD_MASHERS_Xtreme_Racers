using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Track next;
    void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Touch!");
		CarLapCounter carLapCounter = other.gameObject.GetComponent<CarLapCounter>();
		if (carLapCounter) {
			Debug.Log("lap trigger " + gameObject.name);
			carLapCounter.OnLapTrigger(this);
		}
	}
    
}

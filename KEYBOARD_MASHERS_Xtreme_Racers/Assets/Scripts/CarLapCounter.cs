using UnityEngine;
using System.Collections;

public class CarLapCounter : MonoBehaviour {

	public Track first;
	public TextMesh textMesh;

	Track next;
	
	int _lap;

	// Use this for initialization
	void Start () {
		_lap = 0;
		SetNextTrigger(first);
		// Debug.Log("position: " + next.transform.localPosition);
        // Debug.Log("right: " + next.transform.right);
		//UpdateText();
	}

	// update lap counter text
	// void UpdateText() {
	// 	if (textMesh) {
	// 		textMesh.text = string.Format("Lap {0}", _lap);		
	// 	}
	// }

	// when lap trigger is entered
	public void OnLapTrigger(Track trigger) {
		if (trigger == next) {
			if (first == next) {
				_lap++;
				//UpdateText();
			}
			SetNextTrigger(next);
		}
	}

	void SetNextTrigger(Track trigger) {
		next = trigger.next;
		SendMessage("OnNextTrigger", next, SendMessageOptions.DontRequireReceiver);
	}
}

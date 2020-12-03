using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CarLapCounter : MonoBehaviour
{

	public Track StartFinish;
	public Text lap;
	public Text health;

	public EndGame endGame;

	Track next;

	int currentLap = 1;

	// Use this for initialization
	void Start()
	{
		SetNextTrigger(StartFinish);
		UpdateText();
	}

	// update lap counter text
	void UpdateText()
	{
		if (lap)
		{
			lap.text = string.Format("Lap {0}", currentLap);
		}
		health.text = string.Format("Health: {0}", GlobalManager.maxHealth.ToString());
	}

	public void OnLapTrigger(Track trigger)
	{
		if (trigger == next)
		{
			if (next == StartFinish)
			{
				currentLap++;
				UpdateText();
			}
			SetNextTrigger(next);
		}
	}

	void SetNextTrigger(Track trigger)
	{
		next = trigger.next;
		Debug.Log("next " + next);
		SendMessage("OnNextTrigger", next, SendMessageOptions.DontRequireReceiver);
	}

	void Update()
	{
		// set finishing lap number
		if (currentLap == GlobalManager.laps)
			endGame.onEndGame(gameObject.tag);

	}


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLap : MonoBehaviour
{
    // Start is called before the first frame update

    public int lapNumber;
    public int CheckpointIndex;
    private float timer;

    public Text timerTest;

    private void Start()
    {
        lapNumber = 1;
        CheckpointIndex = 0;
        timerTest = GameObject.Find("Timer").GetComponent<Text>();
    }

    private void Update() {

        if(gameObject.tag =="Player"){
            // display the timer for player
            timer+=Time.deltaTime;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            float fraction = (timer*1000);
            string miliseconds = (fraction%1000).ToString("00");
            timerTest.text = minutes + " : " + seconds + " : " + miliseconds;
        }
        

    }

}

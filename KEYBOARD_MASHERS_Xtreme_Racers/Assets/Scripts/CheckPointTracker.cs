using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTracker : MonoBehaviour
{

    // IMPORTANT:
    // When adding the checkpoints, make sure to name each checkpoint gameobject in order. Start from 0
    // and add the 'checkpoint' tag to each of the checkpoints

    // 

    public int checkPointsPassed;
    private GameObject[] checkpoints;

    private int nextPointer;
    private int total;

    void Start()
    {
        checkPointsPassed = 0;
        nextPointer = 0; 
        checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        total = checkpoints.Length;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("checkpoint")){

            if(other.name == nextPointer.ToString()){
                // make sure counting is correct even if player moving backward or keep hitting the same checkpoint twice or more.

                checkPointsPassed++;
                nextPointer++;
                if(nextPointer == total){
                    //current lap is finished
                    //reset the next pointer to 0 
                    nextPointer = 0;
                }
                Debug.Log(gameObject.name+ " passed checkpoints: " + checkPointsPassed);

                // call to rank racers
                GlobalManager.RankingRacers();
            }
        }
    }
}

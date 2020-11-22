using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLap : MonoBehaviour
{
    // Start is called before the first frame update

    public int lapNumber;
    public int CheckpointIndex;
    private void Start()
    {
        lapNumber = 1;
        CheckpointIndex = 0;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public delegate void TrapHandler();
    public static event TrapHandler onTrap;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Touch!");
            onTrap();
        }
    }
}
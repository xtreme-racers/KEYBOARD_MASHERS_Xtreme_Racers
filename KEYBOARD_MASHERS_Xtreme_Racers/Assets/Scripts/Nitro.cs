using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    public delegate void NitroHandler();
    public static event NitroHandler onNitro;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Touch!");
            onNitro();
        }
    }
}

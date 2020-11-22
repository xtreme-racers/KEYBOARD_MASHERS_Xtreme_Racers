using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public delegate void CoinHandler();
    //public static event CoinHandler onCoin;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Coin!");
            GlobalManager.coins++;
            Debug.Log(GlobalManager.coins);
            Destroy(this.gameObject);
            //TODO: delete the current coin
        }
    }
}
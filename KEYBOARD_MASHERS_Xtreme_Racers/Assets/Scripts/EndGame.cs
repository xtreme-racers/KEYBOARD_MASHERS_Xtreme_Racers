using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    public void onEndGame(string playerName){
        if(playerName == "Player"){

            SceneManager.LoadScene("VictoryScreen");


            //player win
        }else if(playerName == "AI"){
            //player lost

            SceneManager.LoadScene("LosingScreen");
        }
    }
}

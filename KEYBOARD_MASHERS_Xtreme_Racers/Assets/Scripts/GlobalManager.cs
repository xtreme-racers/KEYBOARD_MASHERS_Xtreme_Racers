using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
	public static GlobalManager Instance;

	public static int score = 0;
	public static int difficulty = 1;
	public static float volume = 1.0f;
	public static int damage = 1;
	public static int capacity = 10;
	public static int coins = 10;
	public static int maxHealth = 100;

	public static GameObject[] AIs;
	public static GameObject[] racers;
	public static GameObject player;

	public static Text ranking;

	void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void Start() {
		// Initialize the AIs array and racers array
		// Racer array includes both player and all the AIs automatically

		// IMPORTANT:
		// When adding a new AI, make sure set the tag to "AI" in inspector
		ranking = GameObject.Find("Ranking").GetComponent<Text>();
		player  = GameObject.FindWithTag("Player");
		AIs = GameObject.FindGameObjectsWithTag("AI");

		racers = new GameObject[AIs.Length + 1];
		
		for(int i=0; i<AIs.Length; i++){
			racers[i] = AIs[i];
		}
		racers[racers.Length-1] = player;

	}

	public static void RankingRacers(){
		// call this function to rank all the racers

		// Idea: sort the array by how many checkpoints the racer cross.
		// Top element of the array will be the fastest (1st)

		bool swap = true;

		while(swap){
			swap = false;
			for(int i = racers.Length-1; i>0; i--){
				if(racers[i].GetComponent<CheckPointTracker>().checkPointsPassed > racers[i-1].GetComponent<CheckPointTracker>().checkPointsPassed){
					swap = true;
					GameObject tmp = racers[i-1];
					racers[i-1] = racers[i];
					racers[i] = tmp;
				}
			}
		}

		PrintRanking();
	}

	public static void PrintRanking(){
		// print ranking on screen by using Text
		for(int i=0; i<racers.Length; i++){
			if(racers[i] == player){
				ranking.text = "Player rank: " + (i+1);
				break;
			}
		}
	}


	public static int GetPlayerRanking(){
		// return the player rank as int
		// Call this function at finish line / when game end to get the ranking
		for(int i=0; i<racers.Length; i++){
			if(racers[i] == player){
				return (i+1);
			}
		}

		return -1;
	}

}

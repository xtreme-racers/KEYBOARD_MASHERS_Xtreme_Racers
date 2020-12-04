using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
	public static GlobalManager Instance;

	public static int score = 0;
	public static int difficulty = 1;
	public static float volume = 1.0f;
	public static int damage = 10;
	public static int capacity = 10;
	public static int coins = 10;
	public static int maxHealth = 100;
	public static int laps = 3;
	public static int bullet = 0;

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
		

	}

	

}

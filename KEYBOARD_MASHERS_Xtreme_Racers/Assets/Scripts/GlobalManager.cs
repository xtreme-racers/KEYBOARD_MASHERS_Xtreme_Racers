using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
	
	public static int score = 0;
    public static int difficulty = 1;
	public static float volume = 0.0f;
    public static int skin = 0;
    public static int damage = 1;
    public static int capacity = 10;
	
	void Awake()
	{
		if(Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if(Instance != this)
		{
			Destroy(gameObject);
		}
	}
	
}

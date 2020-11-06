using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetting : MonoBehaviour
{
	private AudioSource audioSrc;
	
	void Start()
	{
		audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = GlobalManager.volume;
	}
	
	public void setVolume(float vol)
	{
		GlobalManager.volume = vol;
		audioSrc.volume = GlobalManager.volume;
	}

}
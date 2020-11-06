using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
	
    void Start()
    {
        slider.value = GlobalManager.volume;
    }
	
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
	
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
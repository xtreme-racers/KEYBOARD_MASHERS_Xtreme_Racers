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
		
    public void playAgain(){
        SceneManager.LoadScene("PlayGame");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

   
}
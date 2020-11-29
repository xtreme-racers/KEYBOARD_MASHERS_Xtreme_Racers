using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
    public static int CarType;
    public GameObject Cement;
    public GameObject Dirt;
	
    void Start()
    {
        slider.value = GlobalManager.volume;
    }
	
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void DirtScene()
    {
        SceneManager.LoadScene("Dirt Road");
    }

    public void CementScene()
    {
        SceneManager.LoadScene("Cement Road");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RedCar()
    {
        CarType = 1;
        Cement.SetActive(true);
        Dirt.SetActive(true);
    }

    public void BlueCar()
    {
        CarType = 2;
        Cement.SetActive(true);
        Dirt.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
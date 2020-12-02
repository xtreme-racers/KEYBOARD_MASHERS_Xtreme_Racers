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
        Debug.Log("Drit Road Loaded");
    }

    public void CementScene()
    {
        SceneManager.LoadScene("Cement Road");
        Debug.Log("Drit Road Loaded");

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
        Debug.Log("Red car Loaded");

    }

    public void BlueCar()
    {
        CarType = 2;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Blue car Loaded");

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
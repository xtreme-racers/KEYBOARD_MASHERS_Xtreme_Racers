using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameMenu : MonoBehaviour
{
    public static int CarType;
    public GameObject Cement;
    public GameObject Dirt;
	public Toggle openCV;
	public Button mainMenu;
	
    void Start()
    {
		openCV.isOn = GlobalManager.openCV;
		openCV.onValueChanged.AddListener((val) => toggleUpdate(val));
		mainMenu.onClick.AddListener(GoToMainMenu);
    }
	
	public void toggleUpdate(bool val)
	{
		GlobalManager.openCV =  openCV.isOn;
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

    public void DirtScene()
    {
        SceneManager.LoadScene("Dirt Road");
        Debug.Log("Dirt Road Loaded");
    }

    public void CementScene()
    {
        SceneManager.LoadScene("Cement Road");
        Debug.Log("Cement Road Loaded");

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Audi()
    {
        CarType = 1;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Audi Loaded");

    }

    public void MiniTruck()
    {
        CarType = 2;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Mini Truck Loaded");

    }
	public void Truck()
    {
        CarType = 3;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Truck Loaded");

    }

    public void Police()
    {
        CarType = 4;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Police car Loaded");

    }
	
	public void Ambulance()
    {
        CarType = 5;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Ambulance Loaded");

    }

    public void BlackViper()
    {
        CarType = 6;
        Cement.SetActive(true);
        Dirt.SetActive(true);
        Debug.Log("Black Viper Loaded");

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
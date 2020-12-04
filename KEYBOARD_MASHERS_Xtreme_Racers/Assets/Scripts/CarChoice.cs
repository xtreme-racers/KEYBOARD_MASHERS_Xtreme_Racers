using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoice : MonoBehaviour
{
    public GameObject Audi;
    public GameObject MiniTruck;
	public GameObject Truck;
    public GameObject Police;
	public GameObject Ambulance;
    public GameObject BlackViper;
    public int CarImport;

    void Start()
    {
        CarImport = PlayGameMenu.CarType;
        if(CarImport == 1)
        {
            Audi.SetActive(true);
        }
        if(CarImport == 2)
        {
            MiniTruck.SetActive(true);
        }
		if(CarImport == 3)
        {
            Truck.SetActive(true);
        }
        if(CarImport == 4)
        {
            Police.SetActive(true);
        }
		if(CarImport == 5)
        {
            Ambulance.SetActive(true);
        }
        if(CarImport == 6)
        {
            BlackViper.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoice : MonoBehaviour
{
    public GameObject Audi;
    public GameObject MiniTruck;
<<<<<<< HEAD
    public GameObject Truck;
    public GameObject Police;
    public GameObject Ambulance;
=======
	public GameObject Truck;
    public GameObject Police;
	public GameObject Ambulance;
>>>>>>> f3266658d6ea73f030428958d853f5f03257c178
    public GameObject BlackViper;
    public int CarImport;

    void Start()
    {
        CarImport = MainMenu.CarType;
        if(CarImport == 1)
        {
            Audi.SetActive(true);
        }
        if (CarImport == 2)
        {
            MiniTruck.SetActive(true);
        }
<<<<<<< HEAD
        if (CarImport == 3)
        {
            Truck.SetActive(true);
        }
        if (CarImport == 4)
        {
            Police.SetActive(true);
        }
        if (CarImport == 5)
        {
            Ambulance.SetActive(true);
        }
        if (CarImport == 6)
=======
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
>>>>>>> f3266658d6ea73f030428958d853f5f03257c178
        {
            BlackViper.SetActive(true);
        }
    }
}
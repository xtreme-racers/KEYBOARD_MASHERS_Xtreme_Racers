using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
	public Toggle easy;
	public Toggle medium;
	public Toggle hard;
	
    // Start is called before the first frame update
    void Start()
    {
        switch(GlobalManager.difficulty)
		{
			case 0:
				easy.isOn = true;
				medium.isOn = false;
				hard.isOn = false;
				break;
			case 1:
				easy.isOn = false;
				medium.isOn = true;
				hard.isOn = false;
				break;
			case 2:
				easy.isOn = false;
				medium.isOn = false;
				hard.isOn = true;
				break;
		}
		
		medium.onValueChanged.AddListener((val) => toggleUpdate(val));
    }

    void toggleUpdate(bool val)
    {
        if (easy.isOn) {
			GlobalManager.difficulty = 0;
		}
		else if (medium.isOn) {
			GlobalManager.difficulty = 1;
		}
		else if (hard.isOn) {
			GlobalManager.difficulty = 1;
		}
    }
}

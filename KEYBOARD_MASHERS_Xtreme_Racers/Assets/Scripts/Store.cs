using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Button damageButton;
    public Button capacityButton;
	public TMP_Text damageText;
    public TMP_Text capacityText;
	public TMP_Text coinText;
    
    void Start()
    {
        damageText.text = GlobalManager.damage.ToString();;
        capacityText.text = GlobalManager.capacity.ToString();
		coinText.text = GlobalManager.coins.ToString();
        damageButton.onClick.AddListener(increaseDamage);
        capacityButton.onClick.AddListener(increaseCapacity);
    }
    
    void increaseDamage()
    {
        if (GlobalManager.coins > 0) {
			GlobalManager.damage+=1;
			GlobalManager.coins-=1;
			damageText.text = GlobalManager.damage.ToString();
			coinText.text = GlobalManager.coins.ToString();
		}
    }
    
    void increaseCapacity()
    {
		if (GlobalManager.coins > 0) {
			GlobalManager.capacity+=1;
			GlobalManager.coins-=1;
			capacityText.text = GlobalManager.capacity.ToString();
			coinText.text = GlobalManager.coins.ToString();
		}
    }
}

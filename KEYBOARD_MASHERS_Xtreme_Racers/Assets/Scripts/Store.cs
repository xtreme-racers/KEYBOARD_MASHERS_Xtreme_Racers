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
	public Button healthButton;
	public TMP_Text damageText;
    public TMP_Text capacityText;
	public TMP_Text healthText;
	public TMP_Text coinText;
    
    void Start()
    {
        damageText.text = GlobalManager.damage.ToString();;
        capacityText.text = GlobalManager.capacity.ToString();
		coinText.text = GlobalManager.coins.ToString();
		healthText.text = GlobalManager.maxHealth.ToString();
        damageButton.onClick.AddListener(increaseDamage);
        capacityButton.onClick.AddListener(increaseCapacity);
		healthButton.onClick.AddListener(increaseHealth);
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
	
	void increaseHealth()
    {
		if (GlobalManager.coins > 0) {
			GlobalManager.maxHealth+=1;
			GlobalManager.coins-=1;
			healthText.text = GlobalManager.maxHealth.ToString();
			coinText.text = GlobalManager.coins.ToString();
		}
    }
}

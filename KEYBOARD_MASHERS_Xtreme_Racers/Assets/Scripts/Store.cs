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
    
    void Start()
    {
        damageText.text = GlobalManager.damage.ToString();;
        capacityText.text = GlobalManager.capacity.ToString();
        damageButton.onClick.AddListener(increaseDamage);
        capacityButton.onClick.AddListener(increaseCapacity);
    }
    
    void increaseDamage()
    {
        GlobalManager.damage+=1;
        damageText.text = GlobalManager.damage.ToString();;
    }
    
    void increaseCapacity()
    {
        GlobalManager.capacity+=1;
        capacityText.text = GlobalManager.capacity.ToString();;
    }
}

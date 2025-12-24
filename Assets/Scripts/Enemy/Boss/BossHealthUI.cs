using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{

    private Slider slider;
    private CharacterStat myStats;
    private void Start()
    {      
        slider = GetComponentInChildren<Slider>();
        myStats = GetComponentInParent<CharacterStat>();

        
        myStats.onHealthChanged += UpdateHealthUI;
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {

        slider.maxValue = myStats.GetMaxHealthValue();
        slider.value = myStats.currentHealth;
    }
    private void OnDisable()
    {      
        myStats.onHealthChanged -= UpdateHealthUI;
    }



}

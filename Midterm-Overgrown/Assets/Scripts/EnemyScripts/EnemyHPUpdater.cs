using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EnemyHPUpdater : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateHealth(int CurrentHealth, int MaxHealth)
    {
        TextMeshProUGUI textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = "HP:" + CurrentHealth + "/" + MaxHealth;
    }
}

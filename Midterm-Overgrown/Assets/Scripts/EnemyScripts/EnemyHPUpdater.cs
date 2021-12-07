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

    public void UpdateHealth(int CurrentHealth, int MaxHealth, int BlockAmount)
    {
        TextMeshProUGUI textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = "BP: " + BlockAmount + " HP:" + CurrentHealth + "/" + MaxHealth;
    }
}

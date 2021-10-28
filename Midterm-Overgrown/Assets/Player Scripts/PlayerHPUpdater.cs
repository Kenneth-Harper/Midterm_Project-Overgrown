using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class PlayerHPUpdater : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void UpdateHealth()
    {
        TextMeshProUGUI textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = "BP: " + Player.instance._PlayerBlock + " HP:" + Player.instance._PlayerHealth + "/" + Player.instance._MaxPlayerHealth;
    }
}

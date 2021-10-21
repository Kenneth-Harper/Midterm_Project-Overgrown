using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EnergyGauge : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void UpdateEnergy(int _CurrentEnergy)
    {
        TextMeshProUGUI textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = _CurrentEnergy + "/" + Player.instance._MaxPlayerEnergy;
    }
}

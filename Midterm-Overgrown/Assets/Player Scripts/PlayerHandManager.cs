using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHandManager : MonoBehaviour
{
    void Awake() 
    {
        EncounterEvents.DiscardingHand += OnDiscardingHand;
    }

    void OnDiscardingHand(object sender, EventArgs args)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

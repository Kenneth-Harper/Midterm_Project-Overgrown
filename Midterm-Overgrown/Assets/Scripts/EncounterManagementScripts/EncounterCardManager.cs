using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EncounterCardManager : MonoBehaviour
{
    List<GameObject> CurrentDeck;
    List<GameObject> CurrentHand;
    List<GameObject> CurrentDiscard;

    //private int _MinXCoord = -3;
    //private int _MaxXCoord = 6;


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

    void OnEnable() 
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardScreen : MonoBehaviour
{
    [SerializeField] GameObject Background;

    void Awake()
    {
        EncounterEvents.EndEncounter += OnEndEncounter;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEndEncounter(object sender, EventArgs args)
    {
        Background.GetComponent<SpriteRenderer>().enabled = true;
    }
}

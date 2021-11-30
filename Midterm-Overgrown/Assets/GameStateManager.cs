using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject CombatEncounterSystem;
    [SerializeField] private GameObject ShopEncounterSystem;
    [SerializeField] private GameObject MapSystem;

    void Awake() 
    {
        GameStateEvents.StartMapScreen += OnStartMapScreen;
        GameStateEvents.StartBasicCombatEncounter += OnStartBasicCombatEncounter;
        GameStateEvents.StartShopEncounter += OnStartShopEncounter;
    }

    void Start()
    {
        
    }

    void OnStartMapScreen(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(true);
    }

    void OnStartBasicCombatEncounter(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(true);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
    }

    void OnStartShopEncounter(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(true);
        MapSystem.SetActive(false);
    }
}

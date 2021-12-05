using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameObject CombatEncounterSystem;
    [SerializeField] private GameObject ShopEncounterSystem;
    [SerializeField] private GameObject MapSystem;
    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject GameOverScreen;

    void Awake() 
    {
        GameStateEvents.StartMapScreen += OnStartMapScreen;
        GameStateEvents.StartBasicCombatEncounter += OnStartBasicCombatEncounter;
        GameStateEvents.StartShopEncounter += OnStartShopEncounter;
        GameStateEvents.LoadStartScreen += OnLoadStartScreen;
        GameStateEvents.GameOver += OnGameOver;
    }

    void OnStartMapScreen(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(true);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    void OnStartBasicCombatEncounter(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(true);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    void OnStartShopEncounter(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(true);
        MapSystem.SetActive(false);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(false);
    }

    void OnLoadStartScreen(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
        StartScreen.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    void OnGameOver(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(true);
    }
}

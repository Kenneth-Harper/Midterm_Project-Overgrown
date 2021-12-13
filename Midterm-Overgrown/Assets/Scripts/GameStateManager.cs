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
    [SerializeField] private GameObject GameWinScreen;
    [SerializeField] private GameObject CornerUI;


    void Awake() 
    {
        GameStateEvents.StartMapScreen += OnStartMapScreen;
        GameStateEvents.StartBasicCombatEncounter += OnStartBasicCombatEncounter;
        GameStateEvents.StartShopEncounter += OnStartShopEncounter;
        GameStateEvents.LoadStartScreen += OnLoadStartScreen;
        GameStateEvents.GameOver += OnGameOver;
        GameStateEvents.GameWon += OnGameWon;
    }

    void OnStartMapScreen(object sender, EventArgs args)
    {
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(true);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        GameWinScreen.SetActive(false);
        CornerUI.SetActive(true);
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
        GameWinScreen.SetActive(false);
        CornerUI.SetActive(false);
        EnemyManager._IsBossEncounter = false;
    }

    void OnGameOver(object sender, EventArgs args)
    {
        GameStateEvents.InvokeReset();
        EnemyManager._IsBossEncounter = false;
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(true);
        GameWinScreen.SetActive(false);
        CornerUI.SetActive(false);
    }

    void OnGameWon(object sender, EventArgs args)
    {
        GameStateEvents.InvokeReset();
        CombatEncounterSystem.SetActive(false);
        ShopEncounterSystem.SetActive(false);
        MapSystem.SetActive(false);
        StartScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        GameWinScreen.SetActive(true);
        CornerUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateEvents
{
    
    public static EventHandler StartBasicCombatEncounter;

    public static EventHandler StartMapScreen;

    public static EventHandler StartShopEncounter;

    public static EventHandler LoadStartScreen;

    public static EventHandler GameOver;

    public static void InvokeStartBasicCombatEncounter()
    {
        StartBasicCombatEncounter(null, EventArgs.Empty);
    }

    public static void InvokeStartMapScreen()
    {
        StartMapScreen(null, EventArgs.Empty);
    }

    public static void InvokeStartShopEncounter()
    {
        StartShopEncounter(null, EventArgs.Empty);
    }

    public static void InvokeLoadStartScreen()
    {
        LoadStartScreen(null, EventArgs.Empty);
    }

    public static void InvokeGameOver()
    {
        GameOver(null, EventArgs.Empty);
    }
}

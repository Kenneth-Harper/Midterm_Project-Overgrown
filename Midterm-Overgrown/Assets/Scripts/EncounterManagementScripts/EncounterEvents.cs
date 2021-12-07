using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EncounterEnemyDeathArgs : EventArgs
{
    public GameObject deadEnemyObject;
}

public class EncounterSpawningArgs : EventArgs
{
    public List<GameObject> activeEnemies;
}

public static class EncounterEvents
{
    public static event EventHandler LookingForTarget;
    public static event EventHandler PlayerTurnStarted;
    public static event EventHandler PlayerTurnEnded;
    public static event EventHandler EnemyTurnStarted;
    public static event EventHandler EnemyTurnEnded;
    public static event EventHandler DiscardingHand;
    public static event EventHandler<EncounterEnemyDeathArgs> EnemyDied;
    public static event EventHandler RewardScreen;
    public static event EventHandler EndEncounter;
    public static event EventHandler<EncounterSpawningArgs> SetEnemiesForEncounter;

    public static void InvokeLookingForTarget()
    {
        LookingForTarget(null, EventArgs.Empty);
    }

    public static void InvokeTurnEnded()
    {
        PlayerTurnEnded(null, EventArgs.Empty);
    }

    public static void InvokeDiscardingHand()
    {
        DiscardingHand(null, EventArgs.Empty);
    }

    public static void InvokeEnemyTurnStarted()
    {
        EnemyTurnStarted(null, EventArgs.Empty);
    }

    public static void InvokeEnemyTurnEnded()
    {
        EnemyTurnEnded(null, EventArgs.Empty);
    }

    public static void InvokeRewardScreen()
    {
        RewardScreen(null, EventArgs.Empty);
    }

    public static void InvokeEndEncounter()
    {
        EndEncounter(null, EventArgs.Empty);
    }

    public static void InvokeEnemyDied(GameObject deadEnemy)
    {
        EnemyDied(null, new EncounterEnemyDeathArgs {deadEnemyObject = deadEnemy});
    }

    public static void InvokeSetEnemiesForEncounter(List<GameObject> Enemies)
    {
        SetEnemiesForEncounter(null, new EncounterSpawningArgs {activeEnemies = Enemies});
    }
}

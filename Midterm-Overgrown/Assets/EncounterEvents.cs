using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EncounterEventArgs : EventArgs
{
    public GameObject enemyObject;
}

public static class EncounterEvents
{
    public static event EventHandler LookingForTarget;
    public static event EventHandler<EncounterEventArgs> AttackTargetReply;
    public static event EventHandler PlayerTurnEnded;
    public static event EventHandler EnemyTurnStarted;
    public static event EventHandler EnemyTurnEnded;
    public static event EventHandler DiscardingHand;

    public static void InvokeLookingForTarget()
    {
        LookingForTarget(null, EventArgs.Empty);
    }

    public static void InvokeAttackTargetReply(GameObject CardRecipient)
    {
        AttackTargetReply(null, new EncounterEventArgs { enemyObject = CardRecipient});
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
}

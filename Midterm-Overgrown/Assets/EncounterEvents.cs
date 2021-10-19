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

    public static void InvokeLookingForTarget()
    {
        LookingForTarget(null, EventArgs.Empty);
    }

    public static void InvokeAttackTargetReply(GameObject CardRecipient)
    {
        AttackTargetReply(null, new EncounterEventArgs { enemyObject = CardRecipient});
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNode : MapNode
{
    [SerializeField] private GameObject BossMonster;

    public override void PressedEffect()
    {
        this._IsBeingPressed = false;
        this.Deactivate();
        GameStateEvents.InvokeStartBasicCombatEncounter();
        EncounterEvents.InvokeSetEnemiesForEncounter(new List<GameObject>{BossMonster});
    }
}

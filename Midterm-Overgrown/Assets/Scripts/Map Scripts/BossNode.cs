using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNode : MapNode
{
    [SerializeField] private GameObject BossMonster;

    public override void PressedEffect()
    {
        this._IsBeingPressed = false;
        EnemyManager._IsBossEncounter = true;
        this.Deactivate();
        GameStateEvents.InvokeStartBasicCombatEncounter();
        EncounterEvents.InvokeSetEnemiesForEncounter(new List<GameObject>{BossMonster});
    }
}

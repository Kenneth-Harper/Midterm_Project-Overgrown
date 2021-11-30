using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyNode : MapNode
{
    public override void OnMouseUp()
    {
        if (this._IsBeingPressed)
        {
            this._IsBeingPressed = false;
            this.Deactivate();
            GameStateEvents.InvokeStartBasicCombatEncounter();
            
        }
    }
}

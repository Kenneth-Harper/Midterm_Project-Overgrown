using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNode : MapNode
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard_SteamStrike : AttackCard
{
    void Start()
    {
        
    }

    public override void AffectEnemy()
    {
        this.Target.EnemyTakeDamage(this._attackDamage);
        base.CardPlayed();
    }
}

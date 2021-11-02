using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard_IceSpike : AttackCard
{
    int _FrailAmount = 1;
    void Start()
    {
        this._attackDamage = 4;
    }
    public override void AffectEnemy()
    {
        this.Target.EnemyTakeDamage(_attackDamage);
        this.Target.AddFrail(_FrailAmount);
    }
}

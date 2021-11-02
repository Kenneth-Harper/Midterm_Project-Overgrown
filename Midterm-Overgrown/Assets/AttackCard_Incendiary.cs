using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard_Incendiary : AttackCard
{
    int _ScorchAmount = 1;
    void Start()
    {
        this._attackDamage = 4;    
    }

    void Update()
    {
        
    }

    void AffectEnemy()
    {
        this.Target.EnemyTakeDamage(_attackDamage);
        this.Target.AddScorched(_ScorchAmount);
    }
}

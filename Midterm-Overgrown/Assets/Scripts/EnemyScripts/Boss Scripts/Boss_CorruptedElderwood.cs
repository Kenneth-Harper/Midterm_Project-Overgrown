using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_CorruptedElderwood : Enemy
{
    [SerializeField] int StatusAmount = 3;
    [SerializeField] int BlockAmountToAdd = 15;


    public override void TakeTurn()
    {
        int TurnChoice = (int)Random.Range(1,3);
        if (TurnChoice == 1)
        {
            AttackPlayer();
        }
        else if (TurnChoice == 2)
        {
            ApplyStatus();
        }
        else if (TurnChoice == 3)
        {
            GainBlock();
        }
    }

    private void AttackPlayer()
    {
        int _attackValue = UnityEngine.Random.Range(_BottomDamage, _TopDamage);
        Player.instance.PlayerTakeDamage(_attackValue);
    }

    private void ApplyStatus()
    {
        Player.instance.AddHemorrhage(StatusAmount);
    }

    private void GainBlock()
    {
        this._EnemyBlock += BlockAmountToAdd;
    }
}

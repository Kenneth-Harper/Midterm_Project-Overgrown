using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Snapgragon : Enemy
{
    [SerializeField] int StatusAmount = 1;

    public override void TakeTurn()
    {
        int TurnChoice = (int)Random.Range(1,2);
        if (TurnChoice == 1)
        {
            AttackPlayer();
        }
        else if (TurnChoice == 2)
        {
            ApplyStatus();
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
}

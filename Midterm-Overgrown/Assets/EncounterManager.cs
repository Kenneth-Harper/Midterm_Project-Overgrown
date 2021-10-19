using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public EncounterState currentGameState;

    void Start()
    {
        currentGameState = EncounterState.CombatStart;
        Player.instance.ShuffleDeck();
    }

    void InitiateDrawPhase()
    {
        if (currentGameState == EncounterState.CombatStart || currentGameState == EncounterState.EnemyTurnEnd)
        {
            currentGameState = EncounterState.DrawPhase;
            Player.instance.DrawHand();
        }
    }

    void EndPlayerTurn()
    {
        
    }

    void InitiateEnemyTurn()
    {
        
    }

    void Update()
    {
        
    }
}

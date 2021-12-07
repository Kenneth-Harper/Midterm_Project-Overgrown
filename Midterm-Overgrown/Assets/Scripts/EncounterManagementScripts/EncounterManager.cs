using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EncounterManager : MonoBehaviour
{
    public EncounterState currentGameState;
    public EncounterManager instance;
    [SerializeField] GameObject RewardInterface;

    private void Awake() 
    {
        EncounterEvents.PlayerTurnEnded += OnTurnEnded;    
        EncounterEvents.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    void Start()
    {
        instance = this;
        RewardInterface.GetComponent<RewardScreen>().DisableRewardScreen();
        currentGameState = EncounterState.CombatStart;
        Player.instance.DiscardHand();
        Player.instance.ShuffleDeck();
        Invoke("InitiateDrawPhase", 1);
    }

    void OnEnable() 
    {
        RewardInterface.GetComponent<RewardScreen>().DisableRewardScreen();
        currentGameState = EncounterState.CombatStart;
        Player.instance.DiscardHand();
        Player.instance.ShuffleDeck();
        Invoke("InitiateDrawPhase", 1);
    }

    void InitiateDrawPhase()
    {
        if (currentGameState == EncounterState.CombatStart || currentGameState == EncounterState.EnemyTurnEnd)
        {
            currentGameState = EncounterState.DrawPhase;
            Player.instance.DrawHand();
            Invoke("InitiatePlayerTurn", 1);
        }
    }

    void InitiatePlayerTurn()
    {
        if (currentGameState == EncounterState.DrawPhase)
        {
            currentGameState = EncounterState.PlayerTurn;
        }
    }

    public bool IsPlayerTurn()
    {
        return currentGameState == EncounterState.PlayerTurn;
    }

    void OnTurnEnded(object sender, EventArgs args)
    {
        EndPlayerTurn();
        Player.instance.showTurnEnded();
    }

    void EndPlayerTurn()
    {
        if (currentGameState == EncounterState.PlayerTurn)
        {
            currentGameState = EncounterState.PlayerTurnEnd;
            Player.instance.DiscardHand();
            InitiateEnemyTurn();
        }
    }

    void InitiateEnemyTurn()
    {
        if (currentGameState == EncounterState.PlayerTurnEnd)
        {
            currentGameState = EncounterState.EnemyTurnStart;
            EncounterEvents.InvokeDiscardingHand();
            EnemyTurn();
        }
    }

    void EnemyTurn()
    {
        if (currentGameState == EncounterState.EnemyTurnStart)
        {
            currentGameState = EncounterState.EnemyTurn;
            EncounterEvents.InvokeEnemyTurnStarted();
        }
    }

    void OnEnemyTurnEnded(object sender, EventArgs args)
    {
        EndEnemyTurn();
    }

    void EndEnemyTurn()
    {
        if (currentGameState == EncounterState.EnemyTurn)
        {
            currentGameState = EncounterState.EnemyTurnEnd;
            Invoke("InitiateDrawPhase", 1);
        }
    }

    void Update()
    {
        
    }
}

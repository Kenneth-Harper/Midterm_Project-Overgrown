using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    private void Awake() 
    {
        EncounterEvents.EnemyTurnStarted += OnEnemyTurnStarted;    
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnemyTurnStarted(object sender, EventArgs args)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject enemy = gameObject.transform.GetChild(i).gameObject;
            enemy.GetComponent<Enemy>().attackPlayer();
        }
        EncounterEvents.InvokeEnemyTurnEnded();
    }
}

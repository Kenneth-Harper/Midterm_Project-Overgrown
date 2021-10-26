using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemyHealthTexts;

    private void Awake() 
    {
        EncounterEvents.EnemyTurnStarted += OnEnemyTurnStarted;    
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject enemy = gameObject.transform.GetChild(i).gameObject;
            enemy.GetComponent<Enemy>().HealthTextObject = EnemyHealthTexts[i];
        }
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

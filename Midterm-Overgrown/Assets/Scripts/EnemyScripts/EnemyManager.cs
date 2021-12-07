using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemyHealthTexts;

    [SerializeField] List<GameObject> SpawnedEnemies;

    private List<Vector3> EnemyPositions = new List<Vector3>{new Vector3(0.939999998f,0.99000001f,245.71077f), new Vector3(3.15000057f,-1.08000004f,245.71077f), new Vector3(5.3807869f,0.749362707f,122.855392f), new Vector3(8.14999962f,-0.839999974f,122.855392f)};



    private void Awake() 
    {
        EncounterEvents.EnemyTurnStarted += OnEnemyTurnStarted;
        EncounterEvents.EnemyDied += OnEnemyDied;    
        EncounterEvents.SetEnemiesForEncounter += OnSetEnemiesForEncounter;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnSetEnemiesForEncounter(object sender, EncounterSpawningArgs args)
    {
        List<GameObject> TheseEnemies = args.activeEnemies;
        SetEnemies(TheseEnemies);
    }

    private void SetEnemies(List<GameObject> enemies)
    {
        foreach (GameObject monster in enemies)
        {
            GameObject CurrentMonster = Instantiate(monster);
            CurrentMonster.transform.SetParent(this.gameObject.transform);
            SpawnedEnemies.Add(CurrentMonster);
        }
        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {
            GameObject CurrentEnemy = SpawnedEnemies[i];
            Vector3 EnemyPosition = EnemyPositions[i];
            if (i == 0 || i == 2)
            {
                CurrentEnemy.GetComponent<SpriteRenderer>().sortingOrder = -2;
            }
            CurrentEnemy.transform.localPosition = EnemyPosition;
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject enemy = gameObject.transform.GetChild(i).gameObject;
            enemy.GetComponent<Enemy>().HealthTextObject = EnemyHealthTexts[i];
            enemy.GetComponent<Enemy>().InitializeHealth();
        }
    }

    void OnEnemyTurnStarted(object sender, EventArgs args)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject enemy = gameObject.transform.GetChild(i).gameObject;
            enemy.GetComponent<Enemy>().TakeTurn();
        }
        EncounterEvents.InvokeEnemyTurnEnded();
    }

    void OnEnemyDied(object sender, EncounterEnemyDeathArgs args)
    {
        GameObject DeadEnemy = args.deadEnemyObject;
        SpawnedEnemies.Remove(DeadEnemy);
        Destroy(DeadEnemy);
        if (SpawnedEnemies.Count <= 0)
        {
            EncounterEvents.InvokeEndEncounter();
        }
    }
}

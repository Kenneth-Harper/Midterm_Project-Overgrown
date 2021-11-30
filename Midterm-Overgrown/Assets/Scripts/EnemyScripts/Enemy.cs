using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _HealthPoints = 20;
    [SerializeField] int _MaxHealthPoints = 20;
    [SerializeField] int _TopDamage = 10;
    [SerializeField] int _BottomDamage = 5;
    [SerializeField] public GameObject HealthTextObject;
    int _Status_Scorched = 0;
    int _Status_Frail = 0; 
    
    void Awake() 
    {
        EncounterEvents.PlayerTurnEnded += OnTurnEndedForEnemy;      
    }

    void Start()
    {
        HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints);
    }

    // Update is called once per frame
    void Update()
    {
        if (_HealthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseOver() 
    {
        if (Player.instance._IsTargeting)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Player.instance._CurrentTarget = this.gameObject;
        }
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        if (Player.instance._IsTargeting)
        {
            Player.instance._CurrentTarget = null;
        }
    }

    public void AddScorched(int amount)
    {
        _Status_Scorched += amount;
        Debug.Log("Scorched: " + _Status_Scorched);
    }

    public void AddFrail(int amount)
    {
        _Status_Frail += amount;
        Debug.Log("Frail: " + _Status_Frail);
    }

    public void EnemyTakeDamage(int damage)
    {
        if (_Status_Frail > 0)
        {
            _HealthPoints -= (int)(damage * 1.5f);
            --_Status_Frail;
        }
        else
        {
            _HealthPoints -= damage;
        }
        HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints);
        if (_HealthPoints <= 0)
        {
            EncounterEvents.InvokeEnemyDied();
            HealthTextObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

    public void attackPlayer()
    {
        int _attackValue = UnityEngine.Random.Range(_BottomDamage, _TopDamage);
        Player.instance.PlayerTakeDamage(_attackValue);
    }

    public void OnTurnEndedForEnemy(object sender, EventArgs args)
    {
        if (_Status_Scorched > 0)
        {
            float Multiplier = UnityEngine.Random.Range(0.5f, 1.5f);
            int ScorchDamage = (int)(Multiplier * _Status_Scorched);
            if(ScorchDamage == 0)
            {ScorchDamage = 1;}
            _HealthPoints -= ScorchDamage;
            HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints);
            --_Status_Scorched;
        }
    }
}
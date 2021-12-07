using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _HealthPoints = 20;
    [SerializeField] protected int _MaxHealthPoints = 20;
    [SerializeField] protected int _TopDamage = 10;
    [SerializeField] protected int _BottomDamage = 5;

    [SerializeField] protected int _EnemyBlock = 0;

    [SerializeField] public GameObject HealthTextObject;
    int _Status_Scorched = 0;
    int _Status_Frail = 0; 

    private bool _IsDead = false;

    void Awake() 
    {
        EncounterEvents.PlayerTurnEnded += OnTurnEndedForEnemy;      
        EncounterEvents.PlayerTurnStarted += OnPlayerTurnStarted;
    }

    void Start()
    {
        
    }

    public void InitializeHealth()
    {
        HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints, _EnemyBlock);
    }

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
        int Remainder = damage - _EnemyBlock;
        
        if (Remainder > 0)
        {
            _EnemyBlock = 0;
            damage = Remainder;
        }

        if (_Status_Frail > 0)
        {
            _HealthPoints -= (int)(damage * 1.5f);
        }
        else
        {
            _HealthPoints -= damage;
        }
        HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints, _EnemyBlock);
        if (_HealthPoints <= 0)
        {
            _Status_Frail = 0;
            _Status_Scorched = 0;
            EncounterEvents.InvokeEnemyDied(this.gameObject);
            HealthTextObject.GetComponent<TextMeshProUGUI>().enabled = false;
            _IsDead = true;
        }
    }

    public virtual void TakeTurn()
    {
        int _attackValue = UnityEngine.Random.Range(_BottomDamage, _TopDamage);
        Player.instance.PlayerTakeDamage(_attackValue);
    }

    public void OnTurnEndedForEnemy(object sender, EventArgs args)
    {
        if (_Status_Frail > 0)
        {
            _Status_Frail--;
        }
        if (_Status_Scorched > 0)
        {
            float Multiplier = UnityEngine.Random.Range(0.5f, 1.5f);
            int ScorchDamage = (int)(Multiplier * _Status_Scorched);
            if(ScorchDamage == 0)
            {ScorchDamage = 1;}
            _HealthPoints -= ScorchDamage;
            HealthTextObject.GetComponent<EnemyHPUpdater>().UpdateHealth(_HealthPoints, _MaxHealthPoints, _EnemyBlock);
            --_Status_Scorched;
            if (_HealthPoints <= 0)
            {
                EncounterEvents.InvokeEnemyDied(this.gameObject);
                HealthTextObject.GetComponent<TextMeshProUGUI>().enabled = false;
                _IsDead = true;
            }
        }
    }

    public void OnPlayerTurnStarted(object sender, EventArgs args)
    {
        if (_IsDead)
        {
            Destroy(gameObject);
        }
    }
}

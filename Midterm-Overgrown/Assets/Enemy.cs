using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _HealthPoints = 20;
    [SerializeField] int _TopDamage = 10;
    [SerializeField] int _BottomDamage = 5;
    
    
    
    void Start()
    {
        
        Debug.Log("Enemy HP " + _HealthPoints);
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

    public void EnemyTakeDamage(int damage)
    {
        _HealthPoints -= damage;
        Debug.Log("Enemy HP " + _HealthPoints);
    }

    public void attackPlayer()
    {
        int _attackValue = UnityEngine.Random.Range(_BottomDamage, _TopDamage);
        Player.instance.PlayerTakeDamage(_attackValue);
        Debug.Log("Player HP " + Player.instance._PlayerHealth);
    }
}

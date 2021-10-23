using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackCard : MonoBehaviour
{
    [SerializeField] int _attackDamage = 6;
    [SerializeField] int _energyCost = 1;
    int _PlaceInHand;
    Vector3 _PlaceWhenInHand;

    void Start()
    {
        _PlaceWhenInHand = gameObject.transform.position;
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        Vector3 CurrentPos = gameObject.transform.position;
        CurrentPos.y = -3.5f;
        gameObject.transform.position = CurrentPos;

    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
        Vector3 CurrentPos = gameObject.transform.position;
        CurrentPos.y = -5f;
        gameObject.transform.position = CurrentPos;
    }

    private void OnMouseDrag() 
    {
        Player.instance._IsTargeting = true;
        gameObject.transform.position = new Vector3(-10.9f, -2.35f, gameObject.transform.position.z);
    }

    private void OnMouseUp() 
    {
        if (Player.instance._IsTargeting)
        {
            Player.instance._IsTargeting = false;
            gameObject.transform.position = _PlaceWhenInHand;
            if (Player.instance._CurrentTarget != null && Player.instance.CanPlayCard(_energyCost))
            {
                AffectEnemy();
            }
        }
    }

    private void AffectEnemy()
    {
        Player.instance._CurrentTarget.GetComponent<Enemy>().EnemyTakeDamage(_attackDamage);
        Player.instance.PlayCard(_PlaceInHand);
        Player.instance.SpendEnergy(_energyCost);
        Destroy(gameObject);
    }

    public void SetPlaceInHand(int index)
    {
        _PlaceInHand = index;
    }    

    void Update()
    {
        
    }
}

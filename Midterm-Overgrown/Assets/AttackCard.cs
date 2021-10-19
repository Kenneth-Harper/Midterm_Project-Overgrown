using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : MonoBehaviour
{
    [SerializeField] int _attackDamage = 6;

    void Start()
    {
        
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    private void OnMouseDrag() 
    {
        Player.instance._IsTargeting = true;
    }

    private void OnMouseUp() 
    {
        if (Player.instance._IsTargeting)
        {
            Player.instance._IsTargeting = false;
            if (Player.instance._CurrentTarget != null)
            {
                Player.instance._CurrentTarget.GetComponent<Enemy>().EnemyTakeDamage(_attackDamage);
            }
        }
    }

    void Update()
    {
        
    }
}

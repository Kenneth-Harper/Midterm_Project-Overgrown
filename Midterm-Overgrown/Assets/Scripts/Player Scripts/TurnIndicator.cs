using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    [SerializeField] GameObject _DrawPhaseIndicator;
    [SerializeField] GameObject _PlayerTurnIndicator;
    [SerializeField] GameObject _EnemyTurnIndicator;

    void Start()
    {
        _DrawPhaseIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _PlayerTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _EnemyTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _PlayerTurnIndicator.GetComponent<CircleCollider2D>().enabled = false;
    }
   
    void Update()
    {
        
    }

    public void ShowDrawPhase()
    {
        _DrawPhaseIndicator.GetComponent<SpriteRenderer>().enabled = true;
        _PlayerTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _EnemyTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ShowPlayerTurn()
    {
        _DrawPhaseIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _PlayerTurnIndicator.GetComponent<SpriteRenderer>().enabled = true;
        _EnemyTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _PlayerTurnIndicator.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void ShowEnemyTurn()
    {
        _DrawPhaseIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _PlayerTurnIndicator.GetComponent<SpriteRenderer>().enabled = false;
        _EnemyTurnIndicator.GetComponent<SpriteRenderer>().enabled = true;
        _PlayerTurnIndicator.GetComponent<CircleCollider2D>().enabled = false;
    }
}

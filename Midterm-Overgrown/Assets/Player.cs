using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //General Player Deck Variables
    [SerializeField] List<GameObject> _StartDeck;
    List<GameObject> PlayerDeck;
    

    //Variables Involved with the PlayerHand
    [SerializeField] GameObject _PlayerHandObject;
    [SerializeField] List<GameObject> PlayerHandList = new List<GameObject>(6);
    int HandSize = 5;
    

    //Discard Pile
    [SerializeField] List<GameObject> PlayerDiscardPile;
    
    [SerializeField] public int _PlayerHealth = 60;
    [SerializeField] GameObject EnergyText;


    //Player Energy
    [SerializeField] public int _MaxPlayerEnergy = 3;
    int _CurrentPlayerEnergy;


    [SerializeField] GameObject _TurnIndicator;


    //Enemy Target
    public GameObject _CurrentTarget;
    public bool _IsTargeting = false;


    public static Player instance;

    void Start()
    {
        instance = this;
        instance.PlayerDeck = _StartDeck;
        instance._CurrentPlayerEnergy = _MaxPlayerEnergy;
        Debug.Log("Player HP " + _PlayerHealth);
    }

    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        //Shuffling Algorithm found https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/, by Smooth Foundations
        int Count = instance.PlayerDeck.Count;
        int lastIndex = Count - 1;

        for(int i = 0; i < lastIndex; ++i)
        {
            int r = UnityEngine.Random.Range(i, Count);
            GameObject Temp = instance.PlayerDeck[i];
            instance.PlayerDeck[i] = instance.PlayerDeck[r];
            instance.PlayerDeck[r] = Temp;
        }
    }

    public void DrawHand()
    {
        
        _TurnIndicator.GetComponent<TurnIndicator>().ShowDrawPhase();
        instance._CurrentPlayerEnergy = _MaxPlayerEnergy;
        EnergyText.GetComponent<EnergyGauge>().UpdateEnergy(instance._CurrentPlayerEnergy);

        
        for (int index = 0 ; index < instance.HandSize; index++)
        {
            instance.PlayerHandList.Add(instance.PlayerDeck[index]);
            instance.PlayerHandList[index].GetComponent<AttackCard>().SetPlaceInHand(index);
        }

        instance.PlayerDeck.RemoveRange(0, instance.HandSize);

        float ExtraDistance = 2f;

        for (int i = 0; i < instance.PlayerHandList.Count; i++)
        {
            GameObject NewCard = Instantiate(instance.PlayerHandList[i], new Vector3(-15.5f + (ExtraDistance * i), -5f, 0), Quaternion.identity);
            NewCard.transform.SetParent(_PlayerHandObject.transform);
        }
        _TurnIndicator.GetComponent<TurnIndicator>().ShowPlayerTurn();
    }

    public void PlayCard(int index)
    {
        instance.PlayerDiscardPile.Add(instance.PlayerHandList[index]);
        instance.PlayerHandList.RemoveAt(index);
    }

    public void DrawCard()
    {

    }

    public void DiscardHand()
    {
        instance.PlayerDiscardPile.AddRange(instance.PlayerHandList);
        instance.PlayerHandList.Clear();
    }

    public void SpendEnergy(int cost)
    {
        _CurrentPlayerEnergy -= cost;
        EnergyText.GetComponent<EnergyGauge>().UpdateEnergy(_CurrentPlayerEnergy);
    }

    public void PlayerTakeDamage(int damage)
    {
        _PlayerHealth -= damage;
    }

    public bool CanPlayCard(int _energyCost)
    {
        return (instance._CurrentPlayerEnergy - _energyCost) >= 0;
    }

    public void showTurnEnded()
    {
        _TurnIndicator.GetComponent<TurnIndicator>().ShowEnemyTurn();
    }
}

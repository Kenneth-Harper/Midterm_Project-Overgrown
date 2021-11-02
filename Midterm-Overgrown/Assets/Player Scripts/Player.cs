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
    
    //Player Stats
    [SerializeField] public int _PlayerHealth = 60;
    [SerializeField] public int _MaxPlayerHealth = 60;
    public int _PlayerBlock = 0;
    [SerializeField] GameObject HealthText;


    //Player Energy
    [SerializeField] public int _MaxPlayerEnergy = 3;
    int _CurrentPlayerEnergy;
    [SerializeField] GameObject EnergyText;

    [SerializeField] GameObject _TurnIndicator;


    //Enemy Target
    public GameObject _CurrentTarget;
    public bool _IsTargeting = false;


    //Player Currency
    int _PlayerPetals = 0;

    public static Player instance;

    void Awake()
    {
        instance = this;
        instance.PlayerDeck = _StartDeck;
        instance._CurrentPlayerEnergy = _MaxPlayerEnergy;
        EncounterEvents.EndEncounter += OnEndEncounter;
    }

    void Start()
    {
        HealthText.GetComponent<PlayerHPUpdater>().UpdateHealth();
    }

    void Update()
    {
        
    }

    public void ShuffleList(List<GameObject> CardPile)
    {
        //Shuffling Algorithm found at https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/, by Smooth Foundations
        int Count = CardPile.Count;
        int lastIndex = Count - 1;

        for(int i = 0; i < lastIndex; ++i)
        {
            int r = UnityEngine.Random.Range(i, Count);
            GameObject Temp = CardPile[i];
            CardPile[i] = CardPile[r];
            CardPile[r] = Temp;
        }
    }

    public void ShuffleDeck()
    {
        //Shuffling Algorithm found at https://forum.unity.com/threads/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code.241052/, by Smooth Foundations
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

    public void AddCardtoDeck(GameObject card)
    {
        instance.PlayerDeck.Add(card);
    }

    public void DrawHand()
    {   
        instance._PlayerBlock = 0;
        if (instance.PlayerDeck.Count < HandSize)
        {
            instance.ReshuffleDiscardPile();
        }
        _TurnIndicator.GetComponent<TurnIndicator>().ShowDrawPhase();
        HealthText.GetComponent<PlayerHPUpdater>().UpdateHealth();
        instance._CurrentPlayerEnergy = _MaxPlayerEnergy;
        EnergyText.GetComponent<EnergyGauge>().UpdateEnergy(instance._CurrentPlayerEnergy);

        
        for (int index = 0 ; index < instance.HandSize; index++)
        {
            instance.PlayerHandList.Add(instance.PlayerDeck[index]);
            instance.PlayerHandList[index].GetComponent<Card>().SetPlaceInHand(index);
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

    public void ReshuffleDiscardPile()
    {
        ShuffleList(instance.PlayerDiscardPile);
        instance.PlayerDeck.AddRange(instance.PlayerDiscardPile);
        instance.PlayerDiscardPile.Clear();
    }

    public void SpendEnergy(int cost)
    {
        _CurrentPlayerEnergy -= cost;
        EnergyText.GetComponent<EnergyGauge>().UpdateEnergy(_CurrentPlayerEnergy);
    }

    public void AddPetals(int amount)
    {
        _PlayerPetals += amount;
    }

    public void PlayerTakeDamage(int damage)
    {
        int Remainder = damage - instance._PlayerBlock;
        if (Remainder > 0)
        {
            _PlayerBlock = 0;
            _PlayerHealth -= Remainder;
        }
        else
        {
            _PlayerBlock -= damage;
        }
        
        HealthText.GetComponent<PlayerHPUpdater>().UpdateHealth();
    }

    public void AddBlock(int _ValueAdded)
    {
        instance._PlayerBlock += _ValueAdded;
        HealthText.GetComponent<PlayerHPUpdater>().UpdateHealth();
    }

    public bool CanPlayCard(int _energyCost)
    {
        return (instance._CurrentPlayerEnergy - _energyCost) >= 0;
    }

    public void showTurnEnded()
    {
        _TurnIndicator.GetComponent<TurnIndicator>().ShowEnemyTurn();
    }

    void OnEndEncounter(object sender, EventArgs args)
    {
        _TurnIndicator.SetActive(false);
        HealthText.SetActive(false);
        _PlayerHandObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] List<GameObject> _StartDeck;
    List<GameObject> PlayerDeck;
    [SerializeField] List<GameObject> PlayerHand = new List<GameObject>(6);
    int HandSize = 6;
    [SerializeField] List<GameObject> PlayerDiscardPile;
    
    [SerializeField] int _PlayerHealth = 60;
    [SerializeField] GameObject EnergyText;


    public static Player instance;
    
    [SerializeField] public int _MaxPlayerEnergy = 3;
    int _CurrentPlayerEnergy;

    public GameObject _CurrentTarget;
    public bool _IsTargeting = false;

    void Start()
    {
        instance = this;
        instance.PlayerDeck = _StartDeck;
        instance._CurrentPlayerEnergy = _MaxPlayerEnergy;
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
            int r = Random.Range(i, Count);
            GameObject Temp = instance.PlayerDeck[i];
            instance.PlayerDeck[i] = instance.PlayerDeck[r];
            instance.PlayerDeck[r] = Temp;
        }
    }

    public void DrawHand()
    {
        EnergyText.GetComponent<EnergyGauge>().UpdateEnergy(_CurrentPlayerEnergy);
        
        for (int index = 0 ; index < instance.HandSize; index++)
        {
            instance.PlayerHand.Add(instance.PlayerDeck[index]);
            instance.PlayerHand[index].GetComponent<AttackCard>().SetPlaceInHand(index);
        }

        instance.PlayerDeck.RemoveRange(0, instance.HandSize);

        float ExtraDistance = 2f;

        for (int i = 0; i < instance.PlayerHand.Count; i++)
        {
            Instantiate(instance.PlayerHand[i], new Vector3(-15.5f + (ExtraDistance * i), -5f, 0), Quaternion.identity);
        }
    }

    public void PlayCard(int index)
    {
        instance.PlayerDiscardPile.Add(instance.PlayerHand[index]);
        instance.PlayerHand.RemoveAt(index);
    }

    public void DrawCard()
    {

    }

    public void DiscardHand()
    {
        instance.PlayerDiscardPile.AddRange(instance.PlayerHand);
        instance.PlayerHand.Clear();
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
}

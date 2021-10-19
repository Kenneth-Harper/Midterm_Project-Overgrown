using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] List<GameObject> _StartDeck;
    [SerializeField] int _PlayerHealth = 60;
    
    
    List<GameObject> PlayerDeck;
    List<GameObject> PlayerHand;
    int HandSize = 6;
    List<GameObject> PlayerDiscardPile;
    
    
    public static Player instance;
    
    
    int _PlayerEnergy = 4;
    public GameObject _CurrentTarget;
    public bool _IsTargeting = false;

    void Start()
    {
        this.PlayerDeck = _StartDeck;
        instance = this;
    }

    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        int MaxIndex = instance.PlayerDeck.Count;
        List<int> newIndices = new List<int>(MaxIndex);
        List<GameObject> ShuffledDeck = new List<GameObject>(MaxIndex);
        
        for (int i = 0; i < MaxIndex; i++)
        {
            ShuffledDeck.Add(null);
        }

        foreach (GameObject card in instance.PlayerDeck)
        {
            int newIndex = Random.Range(0, MaxIndex);
            if (newIndices.Contains(newIndex))
            {
                while (newIndices.Contains(newIndex))
                {
                    newIndex = Random.Range(0, MaxIndex);
                }
            }
            newIndices.Add(newIndex);
        }

        int DeckOrderIndex = 0;
        foreach (GameObject card in instance.PlayerDeck)
        {
            int ShuffleIndex = newIndices[DeckOrderIndex];
            ShuffledDeck.Insert(ShuffleIndex, card);
            DeckOrderIndex++;
        }

        instance.PlayerDeck = ShuffledDeck;
    }

    public void DrawHand()
    {
        for (int index = 0 ; index < instance.HandSize; index++)
        {
            PlayerHand.Insert(index, instance.PlayerDeck[0]);
            instance.PlayerDeck.RemoveAt(0);
            instance.PlayerDeck.TrimExcess();
        }
    }

    public void DiscardHand()
    {
        instance.PlayerDiscardPile.AddRange(instance.PlayerHand);
        instance.PlayerHand.Clear();
    }

    public void SpendEnergy(int cost)
    {
        _PlayerEnergy -= cost;
    }

    public void PlayerTakeDamage(int damage)
    {
        _PlayerHealth -= damage;
    }
}

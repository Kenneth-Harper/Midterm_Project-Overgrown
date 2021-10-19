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
        instance = this;
        instance.PlayerDeck = _StartDeck;
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
        instance.PlayerDeck.RemoveRange(0, instance.PlayerDeck.Count);

        instance.PlayerDeck.AddRange(ShuffledDeck);

    }

    public void DrawHand()
    {
        for (int index = 0 ; index < instance.HandSize; index++)
        {
            instance.PlayerHand.Add(instance.PlayerDeck[index]);
        }

        instance.PlayerDeck.RemoveRange(0, instance.HandSize - 1);

        foreach (GameObject card in instance.PlayerHand)
        {
            Instantiate(card, new Vector3(-15.5f, -4.6f, 0), Quaternion.identity);
        }
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
        _PlayerEnergy -= cost;
    }

    public void PlayerTakeDamage(int damage)
    {
        _PlayerHealth -= damage;
    }
}

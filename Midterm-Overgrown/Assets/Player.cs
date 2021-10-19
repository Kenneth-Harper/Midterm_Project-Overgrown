using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<GameObject> PlayerDeck;
    [SerializeField] List<GameObject> _StartDeck;
    [SerializeField] int _PlayerHealth = 60;
    public static Player instance;
    int _PlayerEnergy = 4;
    public GameObject _CurrentTarget;

    public bool _IsTargeting = false;

    // Start is called before the first frame update
    void Start()
    {
        this.PlayerDeck = _StartDeck;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        int MaxIndex = instance.PlayerDeck.Count - 1;
        List<int> UsedIndices = new List<int>();
        List<GameObject> ShuffledDeck = new List<GameObject>(instance.PlayerDeck.Count);
        foreach (GameObject card in instance.PlayerDeck)
        {
            int CurrentIndex = Random.Range(0, MaxIndex);
            if (UsedIndices.Contains(CurrentIndex))
            {
                while (UsedIndices.Contains(CurrentIndex))
                {
                    CurrentIndex = Random.Range(0,MaxIndex);
                }
            }
            else
            {
                UsedIndices.Add(CurrentIndex);
            }
            ShuffledDeck.Insert(CurrentIndex, card);
        }
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

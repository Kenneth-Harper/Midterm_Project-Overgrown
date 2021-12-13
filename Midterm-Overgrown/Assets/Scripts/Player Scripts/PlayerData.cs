using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New PlayerData")]
public class PlayerData : ScriptableObject
{
    List<GameObject> PlayerDeck;
    List<GameObject> PlayerBuds;
    public int _PlayerHealth;
    private int _MaxPlayerHealth;
    private int _MaxPlayerEnergy;
    public int _PlayerEnergy;

    public int _PlayerPetals;

    private void Awake() 
    {
        _MaxPlayerHealth = _PlayerHealth;
        _MaxPlayerEnergy = _PlayerEnergy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCard : Card
{
    [SerializeField] private int _BlockValue = 5;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDrag() 
    {
        gameObject.transform.position = new Vector3(-10.9f, -2.35f, gameObject.transform.position.z);    
    }

    private void OnMouseUp() 
    {
        gameObject.transform.position = this._PlaceWhenInHand;
        if (Player.instance.CanPlayCard(this._energyCost))
        {    
                AffectPlayer();
        }
    }

    private void AffectPlayer()
    {
        Player.instance.AddBlock(_BlockValue);
        Player.instance.PlayCard(this._PlaceInHand);
        Player.instance.SpendEnergy(_energyCost);
        Destroy(gameObject);
    }
}

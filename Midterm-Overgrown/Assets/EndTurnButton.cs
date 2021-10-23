using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseDown() 
    {
        EncounterEvents.InvokeTurnEnded();
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

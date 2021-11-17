using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RefreshButton : MonoBehaviour
{
    private bool _IsBeingPressed = false;    
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
        _IsBeingPressed = true;
    }

    private void OnMouseUp()
    {
        if (_IsBeingPressed)
        {
            _IsBeingPressed = false;
            ShopEvents.InvokeRefreshCards();
        }
    }
    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

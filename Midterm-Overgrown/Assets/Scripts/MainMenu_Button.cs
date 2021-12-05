using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Button : MonoBehaviour
{
    private bool _IsBeingPressed = false;    
    
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
            GameStateEvents.InvokeLoadStartScreen();
        }
    }
    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

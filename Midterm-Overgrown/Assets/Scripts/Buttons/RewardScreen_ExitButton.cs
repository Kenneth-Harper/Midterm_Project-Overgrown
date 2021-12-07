using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScreen_ExitButton : MonoBehaviour
{
    private bool _IsBeingPressed = false;  
    [SerializeField] GameObject RewardInterface;

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
            RewardInterface.GetComponent<RewardScreen>().DisableRewardScreen();
            GameStateEvents.InvokeStartMapScreen();
        }
    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

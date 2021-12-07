using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalButton : MonoBehaviour
{
    private bool _IsBeingPressed = false;    
    private int PetalAmount = 36;
    [SerializeField] private GameObject PetalText;
    void Start()
    {
        PetalText.SetActive(true);
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
            Player.instance.AddPetals(PetalAmount);
            PetalText.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
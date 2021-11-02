using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    protected int _PlaceInHand;
    [SerializeField] protected int _energyCost = 1;
    protected Vector3 _PlaceWhenInHand;

    private void Awake() 
    {
         _PlaceWhenInHand = gameObject.transform.position;
    }
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnMouseEnter() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        Vector3 CurrentPos = gameObject.transform.position;
        CurrentPos.y = -3.5f;
        gameObject.transform.position = CurrentPos;

    }

    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
        Vector3 CurrentPos = gameObject.transform.position;
        CurrentPos.y = -5f;
        gameObject.transform.position = CurrentPos;
    }

    public void SetPlaceInHand(int index)
    {
        _PlaceInHand = index;
    }    
}

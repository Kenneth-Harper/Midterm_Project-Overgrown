using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasableCard : MonoBehaviour
{
    private bool _IsBeingPressed = false;
    private int CardShopIndex;
    [SerializeField] GameObject AssociatedCard;
    [SerializeField] bool _IsShopCard;

    private GameObject AssociatedDisplay;
    
    void Start()
    {
        if (_IsShopCard)
        {
            this.gameObject.transform.localScale = new Vector3(0.116161063f,0.116161078f,0.116161071f);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(0.179732412f,0.179732442f,0.179732427f);
        }
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
            if (_IsShopCard)
            {
                if (Player.instance.CanPurchaseCard(AssociatedCard.GetComponent<Card>().GetTrueValue()))
                {
                    Player.instance.AddCardtoDeck(AssociatedCard);
                    Player.instance.SubtractPetals(AssociatedCard.GetComponent<Card>().GetTrueValue());
                    AssociatedDisplay.GetComponent<PetalDisplay>().CardPurchased();
                    Destroy(this.gameObject);
                }
            }
            else
            {
                Player.instance.AddCardtoDeck(AssociatedCard);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnMouseExit() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public int GetCardCost()
    {
        return AssociatedCard.GetComponent<Card>().GetTrueValue();
    }

    public int GetShopIndex()
    {
        return CardShopIndex;
    }

    public void SetShopIndex(int Index)
    {
        CardShopIndex = Index;
    }

    public void SetDisplay(GameObject display)
    {
        AssociatedDisplay = display;
    }

    public void SetAsShopCard()
    {
        _IsShopCard = true;
    }
}

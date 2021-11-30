using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PetalDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _Manager;
    [SerializeField] private GameObject _DisplayText;
    [SerializeField] private GameObject _PurchasableCard;
    void Start()
    {

    }

    public void SetCard(GameObject card)
    {
        _PurchasableCard = card;
        NewPrice();
    }

    void NewPrice()
    {
        int Price = _PurchasableCard.GetComponent<PurchasableCard>().GetCardCost();
        TextMeshProUGUI textComponent = _DisplayText.GetComponent<TextMeshProUGUI>();
        textComponent.text = Price + " Petals";
    }

    public void CardPurchased()
    {
        TextMeshProUGUI textComponent = _DisplayText.GetComponent<TextMeshProUGUI>();
        _Manager.GetComponent<ShopManager>().RemoveActiveCard(_PurchasableCard.GetComponent<PurchasableCard>().GetShopIndex());
        textComponent.text = "";
        _PurchasableCard = null;
    }
}

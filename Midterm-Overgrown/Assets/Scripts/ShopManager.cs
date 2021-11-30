using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    [SerializeField] List<GameObject> AvailableCards;
    [SerializeField] List<GameObject> PetalCostDisplays;
    
    private int _NumberPurchasedThisRefresh = 0;

    private List<Vector3> CardSlots = new List<Vector3>{new Vector3(-18.8700008f,2.04999995f,273.09903f), new Vector3(-16.9099998f,1.97000003f,273.09903f), new Vector3(-14.9200001f,1.98000002f,273.09903f), new Vector3(-12.9200001f,1.95000005f,273.09903f)};

    private List<GameObject> ActiveCards = new List<GameObject>(4);

    void Awake() 
    {
        ShopEvents.RefreshCards += OnRefreshCards;
    }

    void Start()
    {
        RefreshCardShop();
    }

    void OnRefreshCards(object sender, EventArgs args)
    {
        RefreshCardShop();
    }

    void RefreshCardShop()
    {
        _NumberPurchasedThisRefresh = 0;
        foreach (GameObject card in ActiveCards)
        {
            Destroy(card);
        }
        
        ActiveCards.Clear();

        for (int i = 0; i < CardSlots.Count; i++)
        {
            GameObject SelectedCard = AvailableCards[UnityEngine.Random.Range(0, AvailableCards.Count)];
            GameObject CurrentCard = Instantiate(SelectedCard);
            CurrentCard.transform.position = CardSlots[i];
            CurrentCard.transform.parent = this.gameObject.transform;
            ActiveCards.Add(CurrentCard);
            CurrentCard.GetComponent<PurchasableCard>().SetShopIndex(i);
            CurrentCard.GetComponent<PurchasableCard>().SetAsShopCard();
            CurrentCard.GetComponent<PurchasableCard>().SetDisplay(PetalCostDisplays[i]);
            PetalCostDisplays[i].GetComponent<PetalDisplay>().SetCard(CurrentCard);
        }
    }

    public void RemoveActiveCard(int CardIndex)
    {
        if(CardIndex >= ActiveCards.Count)
        {
            CardIndex -= _NumberPurchasedThisRefresh;
        }
        ActiveCards.RemoveAt(CardIndex);
        _NumberPurchasedThisRefresh++;
    }
}

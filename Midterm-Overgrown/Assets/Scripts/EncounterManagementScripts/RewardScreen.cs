using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardScreen : MonoBehaviour
{
    [SerializeField] GameObject Background;
    [SerializeField] GameObject PetalReward;
    [SerializeField] GameObject ThanksText;

    [SerializeField] List<GameObject> AvailableRewards;

    private List<Vector3> RewardCardPositions = new List<Vector3>{new Vector3(-676.077576f,-416.898987f,273.09903f), new Vector3(-672.947571f,-416.858978f,273.09903f)};

    void Awake()
    {
        EncounterEvents.RewardScreen += OnRewardScreen;
        foreach (GameObject Card in AvailableRewards)
        {
            Card.GetComponent<PurchasableCard>().SetAsRewardCard();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEnable() 
    {
        
    }

    void OnRewardScreen(object sender, EventArgs args)
    {
        Background.SetActive(true);
        PetalReward.SetActive(true);
        ThanksText.SetActive(true);
        for (int i = 0; i < RewardCardPositions.Count; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, AvailableRewards.Count);
            GameObject RewardCard = Instantiate(AvailableRewards[RandomIndex]);
            RewardCard.transform.SetParent(this.gameObject.transform);
            RewardCard.transform.localPosition = RewardCardPositions[i];
        }    
    }

    public void DisableRewardScreen()
    {
        Background.SetActive(false);
        PetalReward.SetActive(false);
        ThanksText.SetActive(false);
    }
}

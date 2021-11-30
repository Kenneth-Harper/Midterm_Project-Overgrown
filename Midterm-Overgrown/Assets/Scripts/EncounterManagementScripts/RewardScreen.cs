using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardScreen : MonoBehaviour
{
    [SerializeField] GameObject Background;
    [SerializeField] GameObject CardReward1;
    [SerializeField] GameObject CardReward2;
    [SerializeField] GameObject PetalReward;
    [SerializeField] GameObject ThanksText;

    void Awake()
    {
        EncounterEvents.EndEncounter += OnEndEncounter;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnEndEncounter(object sender, EventArgs args)
    {
        Background.SetActive(true);
        CardReward1.SetActive(true);
        CardReward2.SetActive(true);
        PetalReward.SetActive(true);
        ThanksText.SetActive(true);
    }
}

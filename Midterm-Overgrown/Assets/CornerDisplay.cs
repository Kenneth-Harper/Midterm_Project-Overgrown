using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CornerDisplay : MonoBehaviour
{
    private GameObject HealthText;
    private GameObject PetalText;
    
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject CurrentObject = gameObject.transform.GetChild(i).gameObject;
            string CurrentObjectName = CurrentObject.name;
            if (CurrentObjectName == "HP")
            {
                HealthText = CurrentObject;
            }
            else if (CurrentObjectName == "Petals")
            {
                PetalText = CurrentObject;
            }
        }
    }

    void Update()
    {
        HealthText.GetComponent<TextMeshProUGUI>().text = Player.instance._PlayerHealth + "/" + Player.instance._MaxPlayerHealth;
        PetalText.GetComponent<TextMeshProUGUI>().text = "" + Player.instance._PlayerPetals;
    }
}

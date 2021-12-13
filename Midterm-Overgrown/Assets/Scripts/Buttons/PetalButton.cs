using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PetalButton : MonoBehaviour
{
    private bool _IsBeingPressed = false;    
    private int PetalAmount = 36;
    [SerializeField] private GameObject PetalText;

    Color _BaseColor;

    void Awake() 
    {
        _BaseColor = this.GetComponent<SpriteRenderer>().color;
    }

    void Start()
    {
        PetalText.SetActive(true);
    }

    void Update()
    {
        
    }
    
    void OnEnable() 
    {
        PetalAmount = Random.Range(30, 50);    
        PetalText.SetActive(true);
        TextMeshProUGUI textComponent = PetalText.GetComponent<TextMeshProUGUI>();
        textComponent.text = "Petals: " + PetalAmount;
        this.GetComponent<SpriteRenderer>().color = _BaseColor;
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
        gameObject.GetComponent<SpriteRenderer>().color = _BaseColor;
    }
}

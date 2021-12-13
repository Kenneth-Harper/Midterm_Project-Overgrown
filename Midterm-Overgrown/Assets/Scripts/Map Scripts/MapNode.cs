using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapNode : MonoBehaviour
{
    protected bool _IsBeingPressed = false;
    protected bool _IsActive = false;

    protected bool _HasBeenAccessed = false;

    [SerializeField] private GameObject LineGenerator;

    [SerializeField] private int RoomLevel;

    [SerializeField] private List<GameObject> PriorNodes = new List<GameObject>(1);
    [SerializeField] private List<GameObject> NextNodes = new List<GameObject>(1);

    void Awake() 
    {

    }

    void Start()
    {
        foreach (GameObject Node in NextNodes)
        {
            GameObject CurrentLine = Instantiate(LineGenerator);
            CurrentLine.transform.SetParent(this.gameObject.transform);
            CurrentLine.GetComponent<LineGenerator>().SetStartNode(gameObject);
            CurrentLine.GetComponent<LineGenerator>().SetEndNode(Node);
        }
    }

    private void OnEnable() 
    {
        
    }

    void Update()
    {
        if (this.RoomLevel == 0 & Player.instance.CurrentLevel == 0)
        {
            _IsActive = true;
            Player.instance.IsFirstNode = false;
        }
        else if (this.RoomLevel == Player.instance.CurrentLevel && PriorNodes.Contains(Player.instance.GetLastMapNode()))
        {
            _IsActive = true;
        }
        else
        {
            _IsActive = false;
        }
    }

    private void OnMouseEnter() 
    {
        if(_IsActive)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    private void OnMouseDown() 
    {
        if (_IsActive)
        {
            _IsBeingPressed = true;
        }
    }

    private void OnMouseUp()
    {
        if (_IsBeingPressed)
        {
            _IsBeingPressed = false;
            Player.instance.SetLastMapNode(this.gameObject);
            Player.instance.CurrentLevel++;
            PressedEffect();
        }
    }

    public virtual void PressedEffect()
    {

    }

    private void OnMouseExit() 
    {
        if (_IsActive)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


    protected void Deactivate()
    {
        Player.instance.SetLastMapNode(this.gameObject);
        _IsActive = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void AddPriorNode(GameObject node)
    {
        PriorNodes.Add(node);
    }

    public void AddNextNode(GameObject node)
    {
        NextNodes.Add(node);
    }

    public void SetNodeLevel(int level)
    {
        RoomLevel = level;
    }

    public bool HasPriorNodes()
    {
        bool ReturnedValue = false;
        if (PriorNodes.Count > 0)
        {
            ReturnedValue = true;
        }
        return ReturnedValue;
    }
}

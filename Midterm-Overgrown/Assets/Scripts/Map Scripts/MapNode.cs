using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    protected bool _IsBeingPressed = false;
    protected bool _IsActive = true;

    protected bool _HasBeenAccessed = false;

    [SerializeField] private GameObject LineGenerator;

    [SerializeField] private int RoomLevel;

    [SerializeField] private List<GameObject> PriorNodes = new List<GameObject>(1);
    [SerializeField] private List<GameObject> NextNodes = new List<GameObject>(1);

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

    public virtual void OnMouseUp()
    {
        if (_IsBeingPressed)
        {
            _IsBeingPressed = false;
            
        }
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
        MapController.CurrentLevel++;
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
}

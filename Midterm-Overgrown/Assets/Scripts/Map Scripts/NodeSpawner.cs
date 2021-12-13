using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    private float _MaxYCoord = 14;
    private float _MinYCoord = -14;
    private float _MaxXCoord = 6;
    private float _MinXCoord = -6;
    [SerializeField] int _ShopSpawningPercent;

    [SerializeField] GameObject _ShopNode;
    [SerializeField] GameObject _EnemyEncounterNode;

    [SerializeField] List<GameObject> PossibleEnemies;

    [SerializeField] GameObject _BossEncounterNode;

    private List<List<GameObject>> AllNodes = new List<List<GameObject>>{new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>(), new List<GameObject>()};

    void Start()
    {
        SpawnNodes();
    }

    void SpawnNodes()
    {
        float CurrentYCoord = _MinYCoord;
        for (int i = 0; i < 7; i++)
        {
            int NodesThisLevel = Random.Range(3, 5);
            float XCoordIncrement = (_MaxXCoord - _MinXCoord) / NodesThisLevel;
            float CurrentXCoord = _MinXCoord + (XCoordIncrement / 2);
            for (int j = 0; j < NodesThisLevel; j++)
            {
                GameObject CurrentNode = Instantiate(NewNode());
                AllNodes[i].Add(CurrentNode);
                CurrentNode.transform.SetParent(gameObject.transform);
                CurrentNode.transform.localPosition = new Vector3(CurrentXCoord, CurrentYCoord, 30f);
                CurrentNode.GetComponent<MapNode>().SetNodeLevel(i);
                CurrentXCoord += XCoordIncrement;
            }
            CurrentYCoord += 4;
        }
        
        GameObject ThisBossNode = Instantiate(_BossEncounterNode);
        AllNodes[7].Add(ThisBossNode);
        ThisBossNode.transform.SetParent(gameObject.transform);
        ThisBossNode.transform.localPosition = new Vector3(0f, _MaxYCoord, 30f);
        ThisBossNode.GetComponent<MapNode>().SetNodeLevel(7);

        for (int i = 0; i < 6; i++)
        {
            List<GameObject> NextLevel = AllNodes[i+1];
            foreach(GameObject Node in AllNodes[i])
            {                
                int NumberOfConnections = Random.Range(1,3);
                for (int j = 0; j < NumberOfConnections; j++)
                {
                    if (i == 0)
                    {
                        int NextNodeIndex = Random.Range(0, NextLevel.Count - 1);
                        Node.GetComponent<MapNode>().AddNextNode(NextLevel[NextNodeIndex]);
                        NextLevel[NextNodeIndex].GetComponent<MapNode>().AddPriorNode(Node);
                    }
                    else if (Node.GetComponent<MapNode>().HasPriorNodes() && i > 0)
                    {
                        int NextNodeIndex = Random.Range(0, NextLevel.Count - 1);
                        Node.GetComponent<MapNode>().AddNextNode(NextLevel[NextNodeIndex]);
                        NextLevel[NextNodeIndex].GetComponent<MapNode>().AddPriorNode(Node);
                    }
                    else
                    {
                        Destroy(Node);
                    }
                }
            }
        }

        foreach (GameObject Node in AllNodes[6])
        {
            if (Node.GetComponent<MapNode>().HasPriorNodes())
            {
                Node.GetComponent<MapNode>().AddNextNode(ThisBossNode);
                ThisBossNode.GetComponent<MapNode>().AddPriorNode(Node);
            }
            else
            {
                Destroy(Node);
            }
        }
    }

    private GameObject NewNode()
    {
        int ChoiceNumber = Random.Range(1,100);
        GameObject ReturnedNode = _EnemyEncounterNode;
        if (ChoiceNumber < _ShopSpawningPercent)
        {
            ReturnedNode = _ShopNode;
        }
        else
        {
            int NumberOfEnemies = Random.Range(1 , 4);
            List<GameObject> TheseEnemies = new List<GameObject>(NumberOfEnemies);
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                int MonsterChoice = Random.Range(0, PossibleEnemies.Count - 1);
                TheseEnemies.Add(PossibleEnemies[MonsterChoice]);
            }
            ReturnedNode.GetComponent<BasicEnemyNode>().AddEnemies(TheseEnemies);
        }
        return ReturnedNode;
    }
}

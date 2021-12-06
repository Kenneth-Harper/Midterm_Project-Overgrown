using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject StartNode;
    [SerializeField] protected GameObject EndNode; 

    private LineRenderer LineMaker;

    void Start()
    {
        LineMaker = this.gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (StartNode != null && EndNode != null)
        {
            List<Vector3> pos = new List<Vector3>();
            pos.Add(StartNode.transform.position);
            pos.Add(EndNode.transform.position);
            LineMaker.startWidth = 0.1f;
            LineMaker.endWidth = 0.1f;
            LineMaker.SetPositions(pos.ToArray());
        }
    }

    public void SetStartNode(GameObject node)
    {
        StartNode = node;
    }

    public void SetEndNode(GameObject node)
    {
        EndNode = node;
    }
}

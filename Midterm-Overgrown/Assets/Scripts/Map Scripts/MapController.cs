using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] float _ScrollIncrement;

    public static bool _IsFirstNode = true;

    void Start()
    {
        
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Vector3 currentpos = transform.position;
            currentpos.y = Mathf.Clamp(currentpos.y -= _ScrollIncrement, -10.8f, 10.8f);
            transform.position = currentpos;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Vector3 currentpos = transform.position;
            currentpos.y = Mathf.Clamp(currentpos.y += _ScrollIncrement, -10.8f, 10.8f);
            transform.position = currentpos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRen : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private Transform[] points;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = points.Length;
    }

    void Update()
    {

        // Loops through number of points drawing lines between them
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}

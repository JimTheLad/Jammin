using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRen : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private Transform target;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        //lr.positionCount = 2;
    }

    void Update()
    {

        // Loops through number of points drawing lines between them
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, target.position);
        //float distance = Vector3.Distance (transform.position, target.position);
        //lr.GetComponent<Renderer>().material.mainTextureScale = new Vector2 (distance *1, 1);
        
    }
}

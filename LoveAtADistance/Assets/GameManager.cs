using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    
    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;
    [SerializeField]
    private Transform player3;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Die()
    {
        player1 = spawn1;
        player2 = spawn2;
        player3 = spawn3;
        //RESET ALL INTERACTABLES
    }
}



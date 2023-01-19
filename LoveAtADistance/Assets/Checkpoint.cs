using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private int playerNum = 0;
    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;
    [SerializeField]
    private Transform pos3;
    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerExit2D()//Collider2D col
    {
        playerNum--;
        //STOP TEXT

    }
    private void OnTriggerEnter2D()
    {
        playerNum++;
        if(playerNum > 2)
        {
            gameManager.spawn1 = pos1;
            gameManager.spawn2 = pos2;
            gameManager.spawn3 = pos3;
            //TEXT
        }
    }
}

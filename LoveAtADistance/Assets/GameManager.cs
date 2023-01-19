using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float playerNum;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Die()
    {
        player1.position = spawn1.position;
        player2.position = spawn2.position;
        player3.position = spawn3.position;
        //RESET ALL INTERACTABLES
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
            SceneManager.LoadScene("WinScene");
        }
    }
}



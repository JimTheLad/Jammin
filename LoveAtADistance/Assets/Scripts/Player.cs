using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerCollisionRadius;
    [SerializeField]
    private float speed;
    [SerializeField]
    private KeyCode up, down, left, right;
    public GameObject centre;
    private ConnectionBehaviour connectionBehaviour;
    private bool isValid = true;
    private bool onIce = false;
    private Rigidbody2D body;

    void Start()
    {
        connectionBehaviour = centre.GetComponent<ConnectionBehaviour>();
        body = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = playerCollisionRadius; //BEFORE BALANCE
        if(Input.GetKey(up)) transform.position += new Vector3(0,speed * Time.deltaTime,0);
        if(Input.GetKey(down)) transform.position += new Vector3(0,-(speed * Time.deltaTime),0);
        if(Input.GetKey(left)) transform.position += new Vector3(-(speed * Time.deltaTime),0,0);
        if(Input.GetKey(right)) transform.position += new Vector3(speed * Time.deltaTime,0,0);
        /*
        if(!onIce)
        {
            gameObject.GetComponent<CircleCollider2D>().radius = playerCollisionRadius; //BEFORE BALANCE
            if(Input.GetKey(up)) transform.position += new Vector3(0,speed * Time.deltaTime,0);
            if(Input.GetKey(down)) transform.position += new Vector3(0,-(speed * Time.deltaTime),0);
            if(Input.GetKey(left)) transform.position += new Vector3(-(speed * Time.deltaTime),0,0);
            if(Input.GetKey(right)) transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }else
        {
            gameObject.GetComponent<CircleCollider2D>().radius = playerCollisionRadius; //Constant velocity
            if(Input.GetKey(up)) body.velocity = new Vector3(0,speed * Time.deltaTime,0);
            if(Input.GetKey(down)) body.velocity = new Vector3(0,-(speed * Time.deltaTime),0);
            if(Input.GetKey(left)) body.velocity = new Vector3(-(speed * Time.deltaTime),0,0);
            if(Input.GetKey(right)) body.velocity = new Vector3(speed * Time.deltaTime,0,0);
        }
        */
        
    }
    void LateUpdate()
    {
        if (!isValid)
        {
            centre.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
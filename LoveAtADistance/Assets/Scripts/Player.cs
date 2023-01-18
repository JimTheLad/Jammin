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
    private AudioSource audioSource;
    private ConnectionBehaviour connectionBehaviour;
    private bool isValid = true;
    private bool sliding = false;
    private Rigidbody2D body;

    private bool slideDown = false;
    private bool slideUp = false;
    private bool slideLeft = false;
    private bool slideRight = false;


    void Start()
    {
        connectionBehaviour = centre.GetComponent<ConnectionBehaviour>();
        body = this.GetComponent<Rigidbody2D>();
        audioSource = transform.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(sliding)
        {
            if(slideUp)
            {
                transform.position += new Vector3(0,speed * Time.deltaTime,0);  
            }
            if(slideDown)
            {
                transform.position += new Vector3(0,-(speed * Time.deltaTime),0);  
            }
            if(slideLeft)
            {
                    transform.position += new Vector3(-(speed * Time.deltaTime),0,0);
            }
            if(slideRight)
            {
                    transform.position += new Vector3(speed * Time.deltaTime,0,0);
            }
            
        }else
        {
            gameObject.GetComponent<CircleCollider2D>().radius = playerCollisionRadius; //BEFORE BALANCE
            if(Input.GetKey(up)) transform.position += new Vector3(0,speed * Time.deltaTime,0);
            if(Input.GetKey(down)) transform.position += new Vector3(0,-(speed * Time.deltaTime),0);
            if(Input.GetKey(left)) transform.position += new Vector3(-(speed * Time.deltaTime),0,0);
            if(Input.GetKey(right)) transform.position += new Vector3(speed * Time.deltaTime,0,0);

            if(Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
            {
                audioSource.Play();
            }else audioSource.Stop();
        }
        
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Ice" && !sliding)
        {
            print("in");
            sliding = true;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.transform.tag == "Ice")
        {
            sliding = false;
        }
    }
}
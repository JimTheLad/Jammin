using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField]
    private float speed = 15f;

    [SerializeField]
    private float jumpHight = 3f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public Vector3 move;
    public Vector3 velocity;
    bool isGrounded;


    ////////////////////////
    public GameObject weapon;
    public GameObject hitBox;
    private bool isAttacking;

    ////////////////////////


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2f );
        }



        ///////////////////////////////////////////////////
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            hitBox.SetActive(true);
            //Play animation clip.


        }else if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            hitBox.SetActive(false);
            //Revert to normal position
        }


        if (Input.GetMouseButton(1))
        {

        }
        if (Input.GetMouseButtonUp(1))
        {

        }





        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f || Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {


        
    }
    private void OnCollisionExit(Collision col)
    {

    }



}

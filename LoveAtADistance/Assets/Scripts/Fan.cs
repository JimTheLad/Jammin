
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // Declare a list of Rigidbody objects
    private List<Transform> rigidbodies = new List<Transform>();

    // Declare a public Vector3 to specify the force to apply to the objects in the list
    public float maxForce;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetType() == typeof(BoxCollider2D) && col.tag == "Player")
        {
                rigidbodies.Add(col.GetComponent<Transform>());    
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetType() == typeof(BoxCollider2D) && col.tag == "Player")
        {
                rigidbodies.Remove(col.GetComponent<Transform>());
        }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < rigidbodies.Count; i++)
        {
            rigidbodies[i].position += new Vector3(8f * Time.deltaTime,0,0);
        }
        /*
        // Calculate the force to apply to each object in the list based on its distance from the transform
        foreach (Transform tran in transform)
        {
            //float distance = Vector3.Distance(transform.position, rigidbody.transform.position);
            //float force = maxForce * (1.0f - distance / 10.0f); // Scale the force based on distance
            tran.position += new Vector3(0,15f * Time.deltaTime,0);
            //rigidbody.velocity = force * Vector3.forward;
            //rigidbody.AddForce(force * Vector3.forward);
        }
        */
    }
}
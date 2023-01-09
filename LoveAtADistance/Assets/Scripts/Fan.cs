
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    // Declare a list of Rigidbody objects
    private List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();

    // Declare a public Vector3 to specify the force to apply to the objects in the list
    public float maxForce;

    private void OnTriggerEnter(Collider other)
    {
        print("hi");
        if (other.GetType() == typeof(BoxCollider2D) && other.tag == "Player")
        {
            print("hi");
            // If the object that entered the trigger has a Rigidbody component, add it to the list
            Rigidbody2D rigidbody = other.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbodies.Add(rigidbody);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetType() == typeof(BoxCollider2D) && other.tag == "Player")
        {
            // If the object that exited the trigger has a Rigidbody component, remove it from the list
            Rigidbody2D rigidbody = other.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbodies.Remove(rigidbody);
                print("bye");
            }
        }
    }

    private void FixedUpdate()
    {
        // Calculate the force to apply to each object in the list based on its distance from the transform
        foreach (Rigidbody2D rigidbody in rigidbodies)
        {
            float distance = Vector3.Distance(transform.position, rigidbody.transform.position);
            float force = maxForce * (1.0f - distance / 10.0f); // Scale the force based on distance
            rigidbody.AddForce(force * Vector3.forward);
        }
    }
}
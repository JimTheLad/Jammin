using UnityEngine;

public class Fan : MonoBehaviour
{
    public Vector2 force;

    private void OnTriggerStay2D(Collider2D other)
    {
        float distance = Vector2.Distance(transform.position, other.transform.position);

        Vector2 forceToApply = force * (1.0f - distance);

        other.attachedRigidbody.AddForce(forceToApply);
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    // Speed of the object
    public float moveSpeed = 30f;

    // Lifetime of the object in seconds (to prevent it from persisting too long)
    public float lifetime = 5f;

    private void Start()
    {
        // Automatically destroy the object after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the object forward based on its local forward direction
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the object when it collides with anything
        Destroy(gameObject);

        // Optional: Add effects or logic here, like an explosion
        Debug.Log($"Missile collided with {collision.gameObject.name} and destroyed itself.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Optional: If using triggers instead of collisions
        Destroy(gameObject);

        // Optional: Add effects or logic here, like an explosion
        Debug.Log($"Missile triggered by {other.gameObject.name} and destroyed itself.");
    }
}

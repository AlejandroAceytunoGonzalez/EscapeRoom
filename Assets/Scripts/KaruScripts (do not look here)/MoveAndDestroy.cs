using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    // Speed of the object
    public float moveSpeed = 30f;

    // Lifetime of the object in seconds (to prevent it from persisting too long)
    public float lifetime = 5f;

    // Flag to control movement
    private bool canMove = true;

    private void Start()
    {
        // Automatically destroy the object after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (canMove)
        {
            // Move the object forward based on its local forward direction
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy immediately when hitting the player
            Destroy(gameObject);

            /// TODO: Send player to main corridor
        }

        if (other.CompareTag("ProyectileObstacle"))
        {
            // Stop movement and start the destruction delay
            canMove = false;
            StartCoroutine(DestroyAfterDelay(0.5f)); // Delay of 0.5 seconds
        }
    }

    // Coroutine to handle the delay before destruction
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

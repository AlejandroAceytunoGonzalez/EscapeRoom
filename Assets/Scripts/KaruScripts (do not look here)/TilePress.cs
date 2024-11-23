using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePress : MonoBehaviour
{
    // Amount to lower the object when collided
    public float lowerAmount = 0.2f;

    // Speed of returning to the original position
    public float returnSpeed = 2f;

    // Store the starting position
    private Vector3 startingPosition;

    // Whether the player is currently colliding
    private bool isColliding = false;

    private void Start()
    {
        // Save the object's initial position
        startingPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.gameObject.CompareTag("Player"))
        {
            // Increment the tileCount in GlobalManager
            RogueRoomTileCounter.tileCount += 1;

            // Log the updated tileCount
            Debug.Log("Tile Count: " + RogueRoomTileCounter.tileCount);

            // Lower the object by the specified amount
            Vector3 newPosition = transform.position;
            newPosition.y -= lowerAmount;
            transform.position = newPosition;

            // Set colliding flag
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object leaving collision is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Clear the colliding flag
            isColliding = false;
        }
    }

    private void Update()
    {
        // If not colliding, move back to the starting position
        if (!isColliding)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                startingPosition,
                Time.deltaTime * returnSpeed
            );
        }
    }
}

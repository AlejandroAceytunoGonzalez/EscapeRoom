using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPositions : MonoBehaviour
{
    // Array of target positions
    public Vector3[] targetPositions;

    // Movement speed
    public float speed = 2f;

    private int currentTargetIndex = 0; // Index of the current target position

    void Update()
    {
        // Check if there are target positions set
        if (targetPositions.Length == 0) return;

        // Get the current target position
        Vector3 targetPosition = targetPositions[currentTargetIndex];

        // Move towards the current target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Move to the next position, and loop back to the first position when reaching the last
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
        }
    }
}
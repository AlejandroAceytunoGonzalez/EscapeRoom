using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHint : MonoBehaviour
{
    [SerializeField] private GameObject brick1;
    [SerializeField] private GameObject brick2;
    [SerializeField] private GameObject brick3;
    [SerializeField] private GameObject brick4;

    [SerializeField] private float moveDistance = 1f; // Distance to move each brick
    [SerializeField] private float moveSpeed = 2f; // Speed of movement

    private Vector3 targetPos1, targetPos2, targetPos3, targetPos4;
    private bool isMoving = false;

    private void Start()
    {
        // Calculate target positions for each brick
        targetPos1 = brick1.transform.position + Vector3.forward * moveDistance; // Move brick 1 along positive Z
        targetPos2 = brick2.transform.position + Vector3.back * moveDistance;   // Move brick 2 along negative Z
        targetPos3 = brick3.transform.position + Vector3.back * moveDistance;   // Move brick 3 along negative Z
        targetPos4 = brick4.transform.position + Vector3.forward * moveDistance; // Move brick 4 along positive Z
    }

    public void MoveAllBricks()
    {
        // Ensure the function is only called once
        if (isMoving)
        {
            Debug.Log("MoveAllBricks() has already been called. The bricks are already moving.");
            return; // Stop the function if it's already in progress
        }

        Debug.Log("MoveAllBricks() called."); // Debug message

        // Start the movement if not already moving
        StartCoroutine(MoveBricksCoroutine());
    }

    private IEnumerator MoveBricksCoroutine()
    {
        isMoving = true;
        bool allBricksMoved = false;

        while (!allBricksMoved)
        {
            allBricksMoved = true;

            // Move each brick and check if all have reached their target
            allBricksMoved &= MoveBrick(brick1, ref targetPos1);
            allBricksMoved &= MoveBrick(brick2, ref targetPos2);
            allBricksMoved &= MoveBrick(brick3, ref targetPos3);
            allBricksMoved &= MoveBrick(brick4, ref targetPos4);

            yield return null; // Wait for the next frame
        }

        Debug.Log("All bricks have reached their target positions."); // Debug message
        isMoving = false;
    }

    private bool MoveBrick(GameObject brick, ref Vector3 targetPos)
    {
        if (brick != null)
        {
            // Lerp towards the target position
            brick.transform.position = Vector3.Lerp(
                brick.transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );

            // Debugging: Log current position and target position
            Debug.Log($"Moving brick {brick.name}. Position: {brick.transform.position}, Target: {targetPos}");

            // Clamp movement to stop exactly at the target position
            if (Vector3.Distance(brick.transform.position, targetPos) < 0.01f)
            {
                brick.transform.position = targetPos;
                return true; // Movement for this brick is complete
            }

            return false; // Still moving
        }

        return true; // If the brick is null, treat as "done"
    }
}

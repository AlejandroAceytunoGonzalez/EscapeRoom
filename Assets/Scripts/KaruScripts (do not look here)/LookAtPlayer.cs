using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // The target object to look at
    [SerializeField] private Transform target;

    void Update()
    {
        if (target == null) return; // Exit if no target is assigned

        // Get the direction from this object to the target
        Vector3 direction = target.position - transform.position;

        // Zero out the Y component of the direction to constrain it to the XZ plane
        direction.y = 0;

        // If the direction is non-zero, rotate the object to look at the target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
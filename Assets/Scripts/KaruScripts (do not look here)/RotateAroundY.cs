using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    // Speed of rotation (degrees per second)
    public float rotationSpeed = 50f;

    void Update()
    {
        // Rotate the object around its Y-axis
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }
}

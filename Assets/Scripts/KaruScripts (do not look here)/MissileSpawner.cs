using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    // Reference to the magicMissile prefab
    public GameObject magicMissile;

    // Speed of the magicMissile
    public float missileSpeed = 5f;

    // Offset for the missile spawn point
    public Vector3 spawnOffset = Vector3.zero;

    public void SpawnMissile(Transform callerTransform)
    {
        if (magicMissile != null)
        {
            // Calculate spawn position based on the caller's position and offset
            Vector3 spawnPosition = callerTransform.position + callerTransform.TransformDirection(spawnOffset);

            // Debug the calculated spawn position
            Debug.Log("Calculated Spawn Position: " + spawnPosition);

            // Instantiate the missile
            GameObject missile = Instantiate(magicMissile, spawnPosition, callerTransform.rotation);
        }
        else
        {
            Debug.LogWarning("MagicMissile prefab is not assigned in the MissileSpawner!");
        }
    }
}

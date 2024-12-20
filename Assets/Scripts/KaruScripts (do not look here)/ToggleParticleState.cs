using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleParticleState : MonoBehaviour
{
    // References to the ParticleSystems
    public ParticleSystem particleSystemSuck;
    public ParticleSystem particleSystemPoof;
    
    public MissileSpawner missileSpawner;

    // Track the current state (true = active, false = inactive)
    private bool isActive = false;

    private void Start()
    {
        particleSystemSuck.Stop();
        particleSystemPoof.Stop();
    }

    private void Update()
    {
        // Check tileCount using comparison (==)
        if (RogueRoomTileCounter.tileCount == 1)
        {
            ToggleOnState();
        }
        else
        {
            ToggleOffState();
        }
    }

    public void ToggleOnState()
    {
        if (!isActive) // Check if not already active
        {
            particleSystemSuck.Play();
            isActive = true; // Set state to active
        }
    }

    public void ToggleOffState()
    {
        if (isActive) // Check if currently active
        {
            missileSpawner.SpawnMissile(transform);
            particleSystemSuck.Stop();
            particleSystemPoof.Play();
            isActive = false; // Set state to inactive
        }
    }
}


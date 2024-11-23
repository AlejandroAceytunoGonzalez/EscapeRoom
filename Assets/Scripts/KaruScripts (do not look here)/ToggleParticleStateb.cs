using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleParticleStateb : MonoBehaviour
{
    // References to the ParticleSystems
    public ParticleSystem particleSystemSuck;
    public ParticleSystem particleSystemPoof;

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
        if (RogueRoomTileCounter.tileCount == 3)
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
            particleSystemSuck.Stop();
            particleSystemPoof.Play();
            isActive = false; // Set state to inactive
        }
    }
}


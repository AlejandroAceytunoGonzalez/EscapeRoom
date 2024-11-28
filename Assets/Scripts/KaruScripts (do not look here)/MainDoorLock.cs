using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorLock : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystemMage;
    [SerializeField] private ParticleSystem particleSystemRogue;
    [SerializeField] private ParticleSystem particleSystemCleric;
    [SerializeField] private ParticleSystem particleSystemBard;
    [SerializeField] private ParticleSystem particleSystemLock;

    private void Awake()
    {
        // Ensure all particle systems are turned off on Awake
        if (particleSystemMage != null) particleSystemMage.Stop();
        if (particleSystemRogue != null) particleSystemRogue.Stop();
        if (particleSystemCleric != null) particleSystemCleric.Stop();
        if (particleSystemBard != null) particleSystemBard.Stop();
    }

    private void Update()
    {
        if(GameManager.Instance.PuzzlesSolved[Character.Mage] == true)
        {
            particleSystemMage.Play();
        }

        if(GameManager.Instance.PuzzlesSolved[Character.Rogue] == true)
        {
            particleSystemRogue.Play();
        }

        if(GameManager.Instance.PuzzlesSolved[Character.Cleric] == true)
        {
            particleSystemCleric.Play();
        }

        if(GameManager.Instance.PuzzlesSolved[Character.Bard] == true)
        {
            particleSystemBard.Play();
        }

        if(GameManager.Instance.PuzzlesSolved[Character.Mage] && GameManager.Instance.PuzzlesSolved[Character.Rogue] && GameManager.Instance.PuzzlesSolved[Character.Cleric] && GameManager.Instance.PuzzlesSolved[Character.Bard] == true)
        {
            particleSystemLock.Play();
        }
    }
}

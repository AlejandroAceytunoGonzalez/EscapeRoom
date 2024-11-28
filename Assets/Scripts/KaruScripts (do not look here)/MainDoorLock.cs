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
        if (GameManager.Instance.PuzzlesSolved[Character.Mage] == true)
        {
            particleSystemMage.gameObject.SetActive(true);
        }

        if (GameManager.Instance.PuzzlesSolved[Character.Rogue] == true)
        {
            particleSystemRogue.gameObject.SetActive(true);
        }

        if (GameManager.Instance.PuzzlesSolved[Character.Cleric] == true)
        {
            particleSystemCleric.gameObject.SetActive(true);
        }

        if (GameManager.Instance.PuzzlesSolved[Character.Bard] == true)
        {
            particleSystemBard.gameObject.SetActive(true);
        }

        if (GameManager.Instance.PuzzlesSolved[Character.Mage] || GameManager.Instance.PuzzlesSolved[Character.Rogue] || GameManager.Instance.PuzzlesSolved[Character.Cleric] || GameManager.Instance.PuzzlesSolved[Character.Bard] == true)
        {
            particleSystemLock.gameObject.SetActive(true);
        }
    }
}

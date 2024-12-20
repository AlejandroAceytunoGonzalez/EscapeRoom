using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MirrorPuzzle : MonoBehaviour
{
    [SerializeField, ColorUsage(true, true)] private Color winColor;
    [SerializeField] private AudioSource gearSound;
    [SerializeField] private GameObject mirrorsProjectionsParent;
    [SerializeField] private GameObject mirrorsSwitchesParent;
    [SerializeField] private GameObject gearsParent;

    [SerializeField] private List<bool> mirrorCombination1;
    [SerializeField] private List<bool> mirrorCombination1_2;
    [SerializeField] private List<bool> mirrorCombination2;
    [SerializeField] private List<bool> mirrorCombination3;

    [SerializeField] private GameObject solution1Torch;
    [SerializeField] private GameObject solution2Torch;
    [SerializeField] private GameObject solution3Torch;

    List<bool> mirrorBools;
    List<bool> mirrorStartBools;
    MirrorSwitch[] mirrorsSwitches;
    MirrorSwitch[] mirrorProjections;
    Animator[] gears;

    private void Awake()
    {
        mirrorBools = new List<bool>();

        mirrorsSwitches = mirrorsSwitchesParent.GetComponentsInChildren<MirrorSwitch>();
        mirrorProjections = mirrorsProjectionsParent.GetComponentsInChildren<MirrorSwitch>();
        gears = gearsParent.GetComponentsInChildren<Animator>();

        foreach (MirrorSwitch mirrorSwitch in mirrorsSwitches)
        {
            mirrorBools.Add(mirrorSwitch.isActivated);
        }
        mirrorStartBools = new List<bool>(mirrorBools);

        AdjustListSize(mirrorCombination1, mirrorBools.Count);
        AdjustListSize(mirrorCombination2, mirrorBools.Count);
        AdjustListSize(mirrorCombination3, mirrorBools.Count);
    }

    private void AdjustListSize(List<bool> list, int targetCount)
    {
        while (list.Count < targetCount) list.Add(false);
        while (list.Count > targetCount) list.RemoveAt(list.Count - 1);
    }
    public void TurnSwitch(int index)
    {
        mirrorBools[index] = !mirrorBools[index];
        mirrorsSwitches[index].SetActivated(mirrorBools[index]);
        mirrorProjections[index].SetActivated(mirrorBools[index]);
    }

    public void CheckMirrors()
    {
        UpdateGears();
        bool solution1 = mirrorBools.SequenceEqual(mirrorCombination1);
        solution1 = solution1 || mirrorBools.SequenceEqual(mirrorCombination1_2);
        bool solution2 = mirrorBools.SequenceEqual(mirrorCombination2);
        bool solution3 = mirrorBools.SequenceEqual(mirrorCombination3);

        if (solution1) solution1Torch.SetActive(true);
        if (solution2) solution2Torch.SetActive(true);
        if (solution3) solution3Torch.SetActive(true);

        if (solution1Torch.activeSelf && solution2Torch.activeSelf && solution3Torch.activeSelf)
        {
            ParticleSystemRenderer renderer1 = solution1Torch.GetComponentInChildren<ParticleSystemRenderer>();
            renderer1.material.SetColor("_EmissionColor", winColor);
            solution1Torch.GetComponentInChildren<Light>().color = winColor;

            ParticleSystemRenderer renderer2 = solution2Torch.GetComponentInChildren<ParticleSystemRenderer>();
            renderer2.material.SetColor("_EmissionColor", winColor);
            solution2Torch.GetComponentInChildren<Light>().color = winColor;

            ParticleSystemRenderer renderer3 = solution3Torch.GetComponentInChildren<ParticleSystemRenderer>();
            renderer3.material.SetColor("_EmissionColor", winColor);
            solution3Torch.GetComponentInChildren<Light>().color = winColor;


            GameManager.Instance.Solve(Character.Cleric);
        }
    }

    private void UpdateGears()
    {
        gearSound.Play();
        foreach (Animator gear in gears)
        {
            int randomState = Random.Range(0, 3);
            if (randomState == 0)
            {
                gear.SetTrigger("ClockWise");
            }
            else if (randomState == 1)
            {
                gear.SetTrigger("CounterClockWise");
            }
        }
    }
    public void ResetMirrors()
    {
        mirrorBools = new List<bool>(mirrorStartBools);
        for (int i = 0; i < mirrorsSwitches.Length; i++)
        {
            MirrorSwitch mirror = mirrorsSwitches[i];
            MirrorSwitch mirrorProjection = mirrorProjections[i];
            mirror.SetActivated(mirrorBools[i]);
            mirrorProjection.SetActivated(mirrorBools[i]);
        }
        UpdateGears();
    }
}

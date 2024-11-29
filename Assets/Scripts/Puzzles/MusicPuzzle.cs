using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicPuzzle : MonoBehaviour
{
    [SerializeField, ColorUsage(true, true)] private Color winColor;
    [SerializeField] private Transform progressTransform;
    [SerializeField] private float progressFactor;
    [SerializeField] private GameObject musicRollsParent;
    [SerializeField] private float clipLength;
    [SerializeField] private float switchTimeBefore;
    [SerializeField] private float switchTimeDuring;
    [SerializeField] private float timerAfterInteract;
    private List<MusicRoll> musicRolls;

    private List<MusicRoll> selectedRolls = new List<MusicRoll>();

    public Action OnSelect;
    public Action OnFinish;

    private float totalTimer;
    private float timer = 0;
    private int progress = 0;
    private bool canPlay = true;
    private bool isFinished;

    private void Awake()
    {
        musicRolls = musicRollsParent.GetComponentsInChildren<MusicRoll>().ToList();
        totalTimer = musicRolls.Count * clipLength / 3;
        CheckRolls();
    }

    private void Update()
    {
        if (canPlay && !isFinished)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = totalTimer;
                StartCoroutine(PlaySounds());
                if (progress >= 9)
                {
                    isFinished = true;
                }
            }
        }
    }
    private IEnumerator PlaySounds()
    {
        for (int i = 0; i < musicRolls.Count; i += 3)
        {
            for (int j = i; j < i + 3 && j < musicRolls.Count; j++)
            {
                musicRolls[j].PlaySound();
            }
            yield return new WaitForSeconds(clipLength);
        }
        if (isFinished)
        {
            OnFinish?.Invoke();
        }
    }
    public void Select(MusicRoll roll)
    {
        if (GameManager.Instance.PuzzlesSolved[Character.Bard]) return;
        OnSelect?.Invoke();
        canPlay = false;
        if (selectedRolls.Count == 0)
        {
            StopAllCoroutines();
            selectedRolls.Add(roll);
            roll.SelectAnim(true);
        }
        else if (selectedRolls.Count == 1)
        {
            //checkSame roll to cancel swap
            selectedRolls.Add(roll);
            roll.SelectAnim(false);
            StartCoroutine(ChangeAnim());
        }
    }

    private IEnumerator ChangeAnim()
    {
        yield return new WaitForSeconds(switchTimeBefore);
        SwithRolls();
        yield return new WaitForSeconds(switchTimeDuring);
        timer = timerAfterInteract;
        canPlay = true;
        selectedRolls.Clear();
    }

    private void SwithRolls()
    {
        int index0 = musicRolls.IndexOf(selectedRolls[0]);
        int index1 = musicRolls.IndexOf(selectedRolls[1]);
        float rot0 = selectedRolls[0].GetRotation();
        float rot1 = selectedRolls[1].GetRotation();
        musicRolls[index0] = selectedRolls[1];
        musicRolls[index1] = selectedRolls[0];
        selectedRolls[0].SwitchRot(rot1);
        selectedRolls[1].SwitchRot(rot0);
        CheckRolls();
    }

    private void CheckRolls()
    {
        progress = 0;
        int groupIndex = 0;
        for (int i = 0; i < musicRolls.Count; i += 3)
        {
            for (int j = i; j < i + 3 && j < musicRolls.Count; j++)
            {
                if (musicRolls[j].intendedSet == groupIndex) progress++;
            }
            groupIndex++;
        }
        if (progress >= 9)
        {
            GameManager.Instance.Solve(Character.Bard);
            progressTransform.GetComponent<Renderer>().material.SetColor("_EmissionColor", winColor);
        }
        progressTransform.localPosition = new Vector3(0, progressFactor * progress, 0);
    }
}

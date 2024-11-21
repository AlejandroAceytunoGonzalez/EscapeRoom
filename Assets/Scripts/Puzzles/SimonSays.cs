using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
public class SimonSays : MonoBehaviour
{
    private List<SimonRune> simonRunes = new List<SimonRune>();

    [SerializeField] private int simonStepsCount = 10;
    [SerializeField] private float displayCooldown = 0.5f;
    [SerializeField] private ParticleSystem fireOrb;
    private List<int> sequenceIndexes = new List<int>();
    private int currentStep = 0;

    public bool isGameActive { get; private set; } = false;

    private void Awake()
    {
        SimonRune[] array = GetComponentsInChildren<SimonRune>();
        for (int i = 0; i < array.Length; i++)
        {
            SimonRune rune = array[i];
            simonRunes.Add(rune);
            int runeIndex = i; // this is necessary cuz memory things

            Interactable interactor = rune.gameObject.GetComponent<Interactable>();
            UnityEvent unityEvent = interactor.GetUnityEvent();
            unityEvent.AddListener(() => RegisterSimonEntry(runeIndex, rune));
        }
        StartNewGame();
    }

    private void GenerateSequence()
    {
        sequenceIndexes.Clear();
        List<int> availableIndices = Enumerable.Range(0, simonRunes.Count).ToList();
        for (int i = 0; i < simonStepsCount; i++)
        {
            if (availableIndices.Count == 0)
            {
                return;
            }
            int randomIndex = Random.Range(0, availableIndices.Count);
            sequenceIndexes.Add(availableIndices[randomIndex]);
            availableIndices.RemoveAt(randomIndex);
        }
    }
    public void StartNewGame()
    {
        currentStep = 0;
        GenerateSequence();
        StartCoroutine(DisplaySequence());
    }
    public void ManualDisplay()
    {
        isGameActive = false;
        StopAllCoroutines();
        StartCoroutine(DisplaySequence());
    }
    private IEnumerator DisplaySequence()
    {
        for (int i = 0; i < sequenceIndexes.Count; i++)
        {
            {
                int index = sequenceIndexes[i];
                SimonRune rune = simonRunes[index];
                var fireOrbMain = fireOrb.main;
                fireOrbMain.startColor = rune.Display();
                yield return new WaitForSeconds(displayCooldown);
            }
        }
        isGameActive = true;
    }

    public void RegisterSimonEntry(int selectedIndex, SimonRune rune)
    {
        rune.Push(isGameActive);
        if (!isGameActive) return;
        if (selectedIndex == sequenceIndexes[currentStep])
        {
            currentStep++;
            if (currentStep >= sequenceIndexes.Count)
            {
                var fireOrbMain = fireOrb.main;
                fireOrbMain.startColor = rune.Display();
                rune.WinEffect();
                OnWin();
            }
            else
            {
                var fireOrbMain = fireOrb.main;
                fireOrbMain.startColor = rune.Display();
                rune.CorrectEffect();
            }
        }
        else
        {
            rune.LoseEffect();
            OnLoss();
        }
    }

    private void OnLoss()
    {
        isGameActive = false;
    }

    private void OnWin()
    {
        isGameActive = false;
    }
}

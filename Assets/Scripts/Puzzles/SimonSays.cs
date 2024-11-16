using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.Events;
using System.Collections;
public class SimonSays : MonoBehaviour
{
    private List<SimonRune> simonRunes = new List<SimonRune>();

    [SerializeField] private int simonStepsCount = 10;
    [SerializeField] private float displayCooldown = 0.5f;
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
        for (int i = 0; i < simonStepsCount; i++)
        {
            int randomIndex = Random.Range(0, simonRunes.Count);
            sequenceIndexes.Add(randomIndex);
        }
    }
    public void StartNewGame()
    {
        currentStep = 0;
        GenerateSequence();
        StartCoroutine(DisplaySequence());
    }
    private IEnumerator DisplaySequence()
    {
        for (int i = 0; i < sequenceIndexes.Count; i++)
        {
            {
                int index = sequenceIndexes[i];
                SimonRune rune = simonRunes[index];
                rune.Display();
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
                rune.WinEffect();
                OnWin();
            }
            else
            {
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

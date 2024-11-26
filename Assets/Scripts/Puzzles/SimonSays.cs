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
    [SerializeField] private Light orbLight;
    private List<int> sequenceIndexes = new List<int>();
    private int currentStep = 0;
    private bool wrongRefresh;

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
                ParticleSystemRenderer renderer = fireOrb.GetComponent<ParticleSystemRenderer>();
                Color color = rune.Display();
                renderer.material.SetColor("_EmissionColor", color * 3);
                orbLight.color = color;
                yield return new WaitForSeconds(displayCooldown);
            }
        }
        if (wrongRefresh)
        {
            wrongRefresh = false;
            foreach (SimonRune rune in simonRunes)
            {
                rune.Reset();
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
                ParticleSystemRenderer renderer = fireOrb.GetComponent<ParticleSystemRenderer>();
                Color color = rune.Display();
                renderer.material.SetColor("_EmissionColor", color * 3);
                orbLight.color = color;
                OnWin();
            }
            else
            {
                ParticleSystemRenderer renderer = fireOrb.GetComponent<ParticleSystemRenderer>();
                Color color = rune.Display();
                renderer.material.SetColor("_EmissionColor", color * 3);
                orbLight.color = color;
                rune.CorrectEffect();
            }
        }
        else
        {
            OnLoss();
        }
    }

    private void OnLoss()
    {
        isGameActive = false;
        foreach (SimonRune rune in simonRunes)
        {
            rune.LoseEffect();
        }
        wrongRefresh = true;
        StartNewGame();
    }

    private void OnWin()
    {
        isGameActive = false;
        foreach (SimonRune rune in simonRunes)
        {
            rune.WinEffect();
        }
        GameManager.Instance.Solve(Character.Mage);
    }
}

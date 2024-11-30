using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DialogueTrigger))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string outroSceneName;
    [SerializeField] private GameObject cursorPrefab;
    [SerializeField] private Transform targetChildCursor;
    public Cursor cursor;
    private DialogueTrigger dialogueTrigger;

    private HashSet<string> visitedScenes = new HashSet<string>();

    public bool hasDied;
    public bool hasDiedAlready;

    public Dictionary<Character, bool> PuzzlesSolved { get; private set; } = new Dictionary<Character, bool>
    {
        { Character.Rogue, false },
        { Character.Mage, false },
        { Character.Cleric, false },
        { Character.Bard, false }
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        dialogueTrigger = GetComponent<DialogueTrigger>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;
        if (sceneName == outroSceneName && cursor != null)
        {
            Destroy(cursor.gameObject);
            cursor = null;
        }
        if (!visitedScenes.Contains(sceneName))
        {
            visitedScenes.Add(sceneName);
            StartCoroutine(InvokedStart(sceneName));
        }
    }
    private IEnumerator InvokedStart(string sceneName)
    {
        yield return new WaitForEndOfFrame();
        dialogueTrigger.DialogueStart(sceneName + "FirstLoad");
    }
    public void Solve(Character character)
    {
        PuzzlesSolved[character] = true;
    }

    public void GenerateCursor()
    {
        GameObject newCursor = Instantiate(cursorPrefab, targetChildCursor.parent.transform);
        int targetIndex = targetChildCursor.transform.GetSiblingIndex();
        newCursor.transform.SetSiblingIndex(targetIndex + 1);
        cursor = newCursor.GetComponent<Cursor>();
    }
}

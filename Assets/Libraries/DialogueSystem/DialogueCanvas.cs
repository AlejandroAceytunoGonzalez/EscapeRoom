using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueCanvas : MonoBehaviour
{
    public static DialogueCanvas Instance { get; private set; }

    public event EventHandler OnDialogueCanvasActiveChange;
    private DialogueInkManager dialogueInk;
    private DialogueSystemDisplay textDisplay;
    private DialogueSystemDisplay optionsDisplay;
    private bool isActive = false;
    private List<ChoiceEvent> choiceEvents;
    private UnityEvent finalEvent;

    /* First Tag Should Be Title of Display */

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        dialogueInk = DialogueInkManager.Instance;
        dialogueInk.OnChosenChoice += Ds_OnChosenChoice;
        dialogueInk.OnContinueStory += Ds_OnContinueStory;
        dialogueInk.OnStoryChoices += Ds_OnStoryChoices;
        dialogueInk.OnStoryEnd += Ds_OnStoryEnd;
    }
    public void StartDialogue(string knotName, DialogueSystemDisplay textDisplay, DialogueSystemDisplay optionsDisplay = null, List<ChoiceEvent> choiceEvents = null, UnityEvent startEvent = null, UnityEvent finalEvent = null)
    {
        ResetDialogue();
        isActive = true;
        OnDialogueCanvasActiveChange?.Invoke(this,EventArgs.Empty);
        if (choiceEvents != null) this.choiceEvents = choiceEvents;
        if (finalEvent != null) this.finalEvent = finalEvent;
        else this.finalEvent = null;
        if (startEvent != null) startEvent?.Invoke();
        this.textDisplay = Instantiate(textDisplay,transform);
        this.optionsDisplay = Instantiate(optionsDisplay,transform);
        DialogueInkManager.Instance.GoToStartOfKnot(knotName);
    }
    private void Ds_OnStoryEnd(object sender, System.EventArgs e)
    {
        ResetDialogue();
        finalEvent?.Invoke();
    }

    private void Ds_OnStoryChoices(object sender, DialogueInkManager.OnStoryChoicesArgs e)
    {
        textDisplay.gameObject.SetActive(false);
        optionsDisplay.gameObject.SetActive(true);

        optionsDisplay.setText(dialogueInk.GetCurrentText());
        if (dialogueInk.GetCurrentTags().Count > 0) optionsDisplay.setTitle(dialogueInk.GetCurrentTags()[0]);
        optionsDisplay.CreateOptions(e.choices, choiceEvents);
    }

    private void Ds_OnContinueStory(object sender, System.EventArgs e)
    {
        textDisplay.gameObject.SetActive(true);
        textDisplay.setText(dialogueInk.GetCurrentText());
        if (dialogueInk.GetCurrentTags().Count > 0) textDisplay.setTitle(dialogueInk.GetCurrentTags()[0]);
    }

    private void Ds_OnChosenChoice(object sender, System.EventArgs e)
    {
        optionsDisplay.gameObject.SetActive(false);
        optionsDisplay.DestroyOptions();
    }
    private void ResetDialogue()
    {
        isActive = false;
        OnDialogueCanvasActiveChange?.Invoke(this, EventArgs.Empty);
        if (textDisplay != null) Destroy(textDisplay.gameObject);
        if (optionsDisplay != null) Destroy(optionsDisplay.gameObject);
        choiceEvents = new List<ChoiceEvent>();
    }
    public bool IsActive()
    {
        return isActive;
    }
}

using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInkManager : MonoBehaviour
{
    public static DialogueInkManager Instance { get; private set; }

    public event EventHandler OnContinueStory;

    public event EventHandler<OnStoryChoicesArgs> OnStoryChoices;
    public class OnStoryChoicesArgs: EventArgs
    {
        public List<Choice> choices;
    }

    public event EventHandler OnChosenChoice;
    public event EventHandler OnStoryEnd;

    public TextAsset inkFile;

    private Story story;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            story = new Story(inkFile.text);
        }
    }
    public void NextLine()
    {
        if (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                OnStoryEnd?.Invoke(this, EventArgs.Empty);
                return;
            }
            if (story.currentChoices.Count > 0)
            {
                //Story has choices in next line
                List<Choice> choices = new List<Choice>();
                foreach (Choice choice in story.currentChoices)
                {
                    choices.Add(choice);
                }
                OnStoryChoices?.Invoke(this, new OnStoryChoicesArgs
                {
                    choices = choices
                });;
            }
            else
            {
                OnContinueStory?.Invoke(this, EventArgs.Empty);
            }
        }
        else if (story.currentChoices.Count == 0)
        {
            OnStoryEnd?.Invoke(this,EventArgs.Empty);
        }
    }
    public void ChooseOption(Choice choice , UnityEvent choiceFunction = null)
    {
        if (story.currentChoices.Count > 0)
        {
            story.ChooseChoiceIndex(choice.index);
            choiceFunction?.Invoke();
            OnChosenChoice?.Invoke(this, EventArgs.Empty);
            NextLine();
        }
    }
    public bool CanContinue()
    {
        return story.canContinue;
    }
    public string GetCurrentText()
    {
        return story.currentText.Trim();
    }
    public List<string> GetCurrentTags()
    {
        return story.currentTags;
    }
    public void GoToStartOfKnot(string knotName)
    {
        Container containerToGo = story.KnotContainerWithName(knotName);
        story.ChoosePath(containerToGo.path);
        NextLine();
    }
}

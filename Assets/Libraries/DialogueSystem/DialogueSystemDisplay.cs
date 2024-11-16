using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueTitle;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Transform optionParent;
    [SerializeField] private OptionButton optionButtonPrefab;
    [SerializeField] private Button continueButton;
    private void Awake()
    {
        if (continueButton != null) continueButton.onClick.AddListener(() => {
            DialogueInkManager.Instance.NextLine();
        });
        gameObject.SetActive(false);
    }
    public void setImage(Sprite image)
    {
        dialogueImage.sprite = image;
    }
    public void setTitle(string title)
    {
        dialogueTitle.text = title;
    }
    public void setText(string dialogue)
    {
        dialogueText.text = dialogue;
    }
    public void CreateOptions(List<Choice> choices,List<ChoiceEvent> choiceEvents = null)
    {
        int index = 0;
        foreach (Choice choice in choices)
        {
            index++;
            OptionButton optionButton = Instantiate(optionButtonPrefab, optionParent);
            optionButton.setText(choice.text,index.ToString());
            Button button = optionButton.gameObject.GetComponent<Button>();
            if(choiceEvents != null)
            {
                bool foundChoice = false; 
                foreach (ChoiceEvent choiceEvent in choiceEvents)
                {
                    if (choice.text == choiceEvent.choiceText)
                    {
                        foundChoice = true;
                        button.onClick.AddListener(() => {
                            DialogueInkManager.Instance.ChooseOption(choice, choiceEvent.choiceEvent);
                        });
                    }
                }
                if (!foundChoice)
                {
                    button.onClick.AddListener(() => {
                        DialogueInkManager.Instance.ChooseOption(choice);
                    });
                }

            }
            else
            {
                button.onClick.AddListener(() => {
                    DialogueInkManager.Instance.ChooseOption(choice);
                });
            }
        }
    }
    public void DestroyOptions()
    {
        foreach(Transform child in optionParent)
        {
            Destroy(child.gameObject);
        }
    }
}

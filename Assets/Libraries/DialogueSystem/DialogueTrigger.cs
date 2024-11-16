using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueSystemDisplay textDisplay;
    [SerializeField] private DialogueSystemDisplay optionsDisplay;
    [SerializeField] private string knotName;
    [SerializeField] private UnityEvent onStartEvent;
    [SerializeField] private UnityEvent onCloseEvent;
    [SerializeField] private List<ChoiceEvent> choiceEvents;
    public void DialogueStart()
    {
        DialogueCanvas.Instance.StartDialogue(knotName,textDisplay,optionsDisplay,choiceEvents, onStartEvent, onCloseEvent);
    }
}

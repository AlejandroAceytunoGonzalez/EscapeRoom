using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnDestroy : MonoBehaviour
{
    private DialogueTrigger dt;
    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
    }
    private void OnDestroy()
    {
        dt.DialogueStart();
    }
}

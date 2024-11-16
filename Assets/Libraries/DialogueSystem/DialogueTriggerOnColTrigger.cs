using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnColTrigger : MonoBehaviour
{
    private DialogueTrigger dt;
    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        dt.DialogueStart();
    }
}

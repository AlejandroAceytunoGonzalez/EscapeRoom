using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOnAwake : MonoBehaviour
{
    private DialogueTrigger dt;
    private void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        dt.Invoke("DialogueStart", 0.01f);
    }
}

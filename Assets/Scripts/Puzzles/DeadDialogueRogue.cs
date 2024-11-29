using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadDialogueRogue : MonoBehaviour
{
    private void Awake()
    {
        DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
        if (GameManager.Instance.hasDied && !GameManager.Instance.hasDiedAlready)
        {
            GameManager.Instance.hasDiedAlready = true;
            StartCoroutine(InvokedStart(dialogueTrigger));
        }
    }
    private IEnumerator InvokedStart(DialogueTrigger dialogueTrigger)
    {
        yield return new WaitForEndOfFrame();
        dialogueTrigger.DialogueStart();
    }
}

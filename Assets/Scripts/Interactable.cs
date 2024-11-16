using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent = new UnityEvent();
    [SerializeField] private InteractableType type = InteractableType.Manual;
    [SerializeField] private float interactionCooldown = -1f; //-1 is only once, 0 is no cooldown.

    private bool isInteracted;

    private void Interact()
    {
        if (!isInteracted) {
            isInteracted = true;
            StopAllCoroutines();
            unityEvent.Invoke();
            if(interactionCooldown == 0)
            {
                isInteracted = false;
            }
            else if (interactionCooldown > 0) {
                Invoke("EnableInteraction", interactionCooldown);
            }
        }
    }
    public void SetUnityEvent(UnityEvent unityEvent)
    {
        this.unityEvent = unityEvent;
    }
    public UnityEvent GetUnityEvent()
    { 
        return unityEvent; 
    }
    public void EnableInteraction()
    {
        isInteracted = false;
    }
    public void ManualInteract()
    {
        if (type == InteractableType.Manual) Interact();
    }
    public void DialogueInteract()
    {
        if (type == InteractableType.Dialogue) Interact();
    }
    public void OnTriggerEnterInteract()
    {
        if (type == InteractableType.OnTriggerEnter) Interact();
    }
    private void OnDisable()
    {
        if (type == InteractableType.OnDisable) Interact();
    }
    private void OnEnable()
    {
        if (type == InteractableType.OnEnable) Interact();
    }

}
public enum InteractableType
{
    Manual,
    Dialogue,
    OnTriggerEnter,
    OnDisable,
    OnEnable,
}

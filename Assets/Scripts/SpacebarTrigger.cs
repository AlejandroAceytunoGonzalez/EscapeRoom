using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class SpacebarTrigger : MonoBehaviour
{
    [SerializeField] private Animator book;
    private Interactable interactable;
    private bool open = false;
    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }
    private void Update()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            interactable.CodeInteract();
        }
    }
    public void SwitchBookState()
    {
        open = !open;
        book.SetBool("Open", open);
    }
}

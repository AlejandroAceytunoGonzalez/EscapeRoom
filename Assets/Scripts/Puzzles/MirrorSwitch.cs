using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSwitch : MonoBehaviour
{
    [field: SerializeField] public bool isActivated { get; private set; }
    [SerializeField] private Animator animator;
    private void Awake()
    {
        animator.SetBool("IsActivated", isActivated);
        animator.Play(isActivated ? "On" : "Off");
    }

    public void SetActivated(bool state)
    {
        isActivated = state;
        animator.SetBool("IsActivated", state);
    }
}

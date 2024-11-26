using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSwitch : MonoBehaviour
{
    [field: SerializeField] public bool isActivated { get; private set; }
    [SerializeField] private Animator animator;
    [SerializeField] private List<int> indexes;
    private MirrorPuzzle puzzle;
    private void Awake()
    {
        puzzle = FindObjectOfType<MirrorPuzzle>();
        animator.SetBool("IsActivated", isActivated);
        animator.Play(isActivated ? "On" : "Off");
    }

    public void SetActivated(bool state)
    {
        isActivated = state;
        animator.SetBool("IsActivated", state);
    }
    public void Switch()
    {
        foreach (var index in indexes) {
            puzzle.TurnSwitch(index);
        }
        puzzle.CheckMirrors();
    }
}

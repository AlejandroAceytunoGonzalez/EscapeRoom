using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
[RequireComponent(typeof(Interactable))]
public class DoorLogic : MonoBehaviour
{
    [SerializeField] private bool hasRestrictions = true;
    [SerializeField] private bool isKiller = false;
    [SerializeField] private string sceneName;
    [SerializeField] private Vector3 destinationPos;
    [SerializeField] [Range(-180,180)] private float destinationRotationPov;
    [SerializeField] private Character assignedCharacter;
    [SerializeField] private string wrongCharacterKnot;
    [SerializeField] private string alreadySolvedKnot;
    [SerializeField] private float afterDialogueCooldown = 1f;
    private DialogueTrigger dialogueTrigger;
    private Interactable interactor;
    private SceneChanger sceneChanger;
    private PlayerController player;


    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        interactor = GetComponent<Interactable>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        player = FindObjectOfType<PlayerController>();
    }

    public void TryDoor()
    {
        if (hasRestrictions)
        {
            GameManager.Instance.PuzzlesSolved.TryGetValue(assignedCharacter, out bool solved);
            if (solved)
            {
                dialogueTrigger.DialogueStart(alreadySolvedKnot);
                return;
            }
            if (player.playerCharacter != assignedCharacter)
            {
                dialogueTrigger.DialogueStart(wrongCharacterKnot);
                return;
            }
        }
        if (isKiller) GameManager.Instance.hasDied = true;
        sceneChanger.ChangeScene(sceneName, player.playerCharacter , destinationPos, destinationRotationPov);
    }
    public void TryDoorReset()
    {
        Invoke(nameof(DoorReset), afterDialogueCooldown);
    }
    private void DoorReset()
    {
        interactor.EnableInteraction();
    }
}

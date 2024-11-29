using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRolls : MonoBehaviour
{
    [SerializeField] private List<Animator> goldenRolls;
    [SerializeField] private bool isDejaVu;
    [SerializeField] private AudioSource finalSong;
    [SerializeField] private float finalSongDialogueTimer = 19f;
    [SerializeField] private DialogueTrigger startSongDialogue;
    [SerializeField] private DialogueTrigger finalSongDialogue;

    [SerializeField] private string sceneName;
    [SerializeField] private Vector3 destinationPos;
    [SerializeField][Range(-180, 180)] private float destinationRotationPov;

    private MusicPuzzle musicPuzzle;
    private void Awake()
    {
        musicPuzzle = FindObjectOfType<MusicPuzzle>();
        musicPuzzle.OnFinish += Finish;
    }
    public void Finish()
    {
        foreach (Animator rotatingAnim in goldenRolls) {
            rotatingAnim.SetBool("Finished", true);
        }
        if (!isDejaVu) {
            finalSong.Play();
            startSongDialogue.DialogueStart();
            Invoke(nameof(FinalSongDialogue), finalSongDialogueTimer);
        }
    }
    private void FinalSongDialogue()
    {
        finalSongDialogue.DialogueStart();
    }
    public void DejaVu()
    {
        SceneChanger sceneChanger = FindObjectOfType<SceneChanger>();
        sceneChanger.ChangeScene(sceneName, Character.Bard, destinationPos, destinationRotationPov);
    }
}

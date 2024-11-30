using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameGuessing : MonoBehaviour
{
    [SerializeField] private string nameToGuess = "PHRACTAS";
    [SerializeField] private string endingNode = "EndingGood";
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private DialogueTrigger endingTrigger;
    [SerializeField] private DialogueTrigger wrongGuess;
    [SerializeField] private string endScene;
    public void EndGame()
    {
        SceneChanger sceneChanger = FindObjectOfType<SceneChanger>();
        sceneChanger.ChangeScene(endScene, Character.Rogue, Vector3.zero, 0);
    }
    public void CheckName()
    {
        if (userInput.text.ToUpper() == nameToGuess.ToUpper())
        {
            endingTrigger.DialogueStart(endingNode);
        }
        else
        {
            wrongGuess.DialogueStart();
        }
    }
}

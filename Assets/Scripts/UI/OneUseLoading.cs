using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUseLoading : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Vector3 destinationPos;
    [SerializeField][Range(-180, 180)] private float destinationRotationPov;
    [SerializeField] private Character assignedCharacter;
    private SceneChanger sceneChanger;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        sceneChanger = GetComponent<SceneChanger>();
    }
    public void IntroEnd()
    {
        sceneChanger.ChangeScene(sceneName, assignedCharacter, destinationPos, destinationRotationPov, gameObject);
    }

}

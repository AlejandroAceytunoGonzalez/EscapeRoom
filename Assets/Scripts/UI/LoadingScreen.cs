using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{ 
    private Animator loadingScreen;
    [field: SerializeField] public float MinLoadtime { get; private set; }

    private void Awake()
    {
        loadingScreen = GetComponent<Animator>();
    }

    public void StartLoading()
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null) playerController.SetCanMove(false);
        loadingScreen.SetBool("isEnabled", true);
    }
    public void EndLoading()
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null) playerController.SetCanMove(true);
        loadingScreen.SetBool("isEnabled", false);
    }
}

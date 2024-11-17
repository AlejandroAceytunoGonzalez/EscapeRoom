using System.Collections;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] Character character;
    private LoadingScreen loadingScreen;
    private PlayerController player;

    private void Awake()
    {
        PlayerController.OnCharacterChange += PlayerController_OnCharacterChange;
    }

    private void PlayerController_OnCharacterChange(Character playerCharacter)
    {
        if (character == playerCharacter)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void SwapCharacter()
    {
        loadingScreen = FindObjectOfType<LoadingScreen>();
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(Trasition());
    }
    private IEnumerator Trasition()
    {
        loadingScreen.StartLoading();
        yield return new WaitForSeconds(loadingScreen.MinLoadtime);
        player.SetCharacter(character);
        loadingScreen.EndLoading();
    }
}

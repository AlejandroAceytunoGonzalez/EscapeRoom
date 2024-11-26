using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private LoadingScreen loadingScreen;

    public void ChangeScene(string sceneName, Character character, Vector3 pos, float rotationPov)
    {
        loadingScreen = FindObjectOfType<LoadingScreen>();
        StartCoroutine(LoadSceneAsync(sceneName, character, pos, rotationPov));
    }
    private IEnumerator LoadSceneAsync(string sceneName, Character character, Vector3 pos, float rotationPov)
    {
        loadingScreen.StartLoading();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(loadingScreen.MinLoadtime);
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                loadingScreen.EndLoading();
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        PlayerController player = FindObjectOfType<PlayerController>();
        player.SetCharacter(character);
        player.SetRotPov(rotationPov);
        player.transform.position = pos;
    }
}

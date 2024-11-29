using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private LoadingScreen loadingScreen;

    public void ChangeScene(string sceneName, Character character, Vector3 pos, float rotationPov, GameObject toDelete = null)
    {
        loadingScreen = FindObjectOfType<LoadingScreen>();
        StartCoroutine(LoadSceneAsync(sceneName, character, pos, rotationPov, toDelete));
    }
    private IEnumerator LoadSceneAsync(string sceneName, Character character, Vector3 pos, float rotationPov, GameObject toDelete = null)
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
        if (player != null)
        {
            player.SetCharacter(character);
            player.SetRotPov(rotationPov);
            player.transform.position = pos;
        }
        StartCoroutine(DestroyLater(toDelete));
    }
    public IEnumerator DestroyLater(GameObject toDelete)
    {
        yield return new WaitForSeconds (loadingScreen.MinLoadtime + 0.5f);
        if (toDelete != null)
        {
            Destroy(toDelete);
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private LoadingScreen loadingScreen;

    public void ChangeScene(string sceneName)
    {
        loadingScreen = FindObjectOfType<LoadingScreen>();
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    private IEnumerator LoadSceneAsync(string sceneName)
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
    }
}

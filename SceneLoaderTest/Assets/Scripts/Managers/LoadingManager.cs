using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    /// <summary>
    /// Loads the specified scene name.
    /// The function will load the Loading Scene which in turn will load the desired scene.
    /// </summary>
    /// <param name="SceneName">string of the scene name</param>
    public static void LoadScene(string SceneName)
    {

    }


    /// <summary>
    /// Coroutine for switching the scene
    /// </summary>
    /// <param name="SceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadSceneCO(string SceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        AppState.isSceneChanging = true;
        AppState.loadingProgress = 0f;
        while (!ao.isDone)
        {
            AppState.loadingProgress = ao.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Returns the current active scene as Scene
    /// </summary>
    /// <returns></returns>
    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


/// <summary>
/// The Loading Singleton
/// </summary>
public class LoadingManager : MonoBehaviour
{
    /// <summary>
    /// Easyer to remember "_" as the instance
    /// </summary>
    public static LoadingManager _ = null;

    /// <summary>
    /// Keep the same camera rig across scenes
    /// </summary>
    public GameObject CameraRig;

    /// <summary>
    /// The AsyncOperation that will load the scene
    /// </summary>
    private AsyncOperation ao;

    private void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }else if (_ != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(CameraRig);
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the specified scene name.
    /// The function will load the Loading Scene which in turn will load the desired scene.
    /// </summary>
    /// <param name="SceneName">string of the scene name</param>
    public void LoadScene(string SceneName)
    {
        AppState.SceneToLoad = SceneName;
        StartCoroutine(LoadSceneCO(Constants.LoadingSceneName));
    }


    /// <summary>
    /// Coroutine for switching the to the Loading scene
    /// </summary>
    /// <param name="SceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadSceneCO(string SceneName)
    {
        // Use a local Async Operation for loading the "Loading scene" and keep the 
        // global private AO for the desired scene.
        AsyncOperation localAO = SceneManager.LoadSceneAsync(SceneName);
        localAO.allowSceneActivation = false;
        AppState.isSceneChanging = true;
        AppState.loadingProgress = 0f;
        
        while (ao.progress<0.9f)
        {
            AppState.loadingProgress = ao.progress;
            Debug.Log(ao.progress);
            yield return new WaitForEndOfFrame();
        }
        ao.allowSceneActivation = true;
        yield return new WaitForEndOfFrame();
        StartCoroutine(LoadDesiredSceneCO(AppState.SceneToLoad));
    }



    /// <summary>
    /// Coroutine for switching the to the Loading scene
    /// </summary>
    /// <param name="SceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadDesiredSceneCO(string SceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        AppState.isSceneChanging = true;
        AppState.loadingProgress = 0f;
        while (ao.progress < 0.9f)
        {
            AppState.loadingProgress = ao.progress;
            yield return new WaitForEndOfFrame();
        }
        ao.allowSceneActivation = true;
        yield return new WaitForEndOfFrame();
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

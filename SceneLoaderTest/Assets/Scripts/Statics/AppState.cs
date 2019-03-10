
public class AppState
{ 
    public enum appStatus {
        Active =0,
        LoadinFromSplashScreen=1,
        LoadingAScene=2,
        Quitting=3        
    }

    public static appStatus Status;
    public static bool isSceneChanging = false;
    public static float loadingProgress = 0f;

    public static string LoadingSceneName= "LoadingScene";
    public static string StartSceneName = "StartScene";


    public static string SceneToLoad = string.Empty;
}

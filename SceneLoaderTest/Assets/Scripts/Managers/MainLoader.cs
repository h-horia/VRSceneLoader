using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoader : MonoBehaviour
{

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        LoadingManager._.LoadScene(Constants.MainScene);
    }
}

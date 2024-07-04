using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using V.TowerDefense;

public static class Loader
{
    private static Action onLoaderCallback;
    private static AsyncOperation ansyLoad;

    private static void Update() 
    {
        if(ansyLoad.isDone) //>= 0.9f)
            ansyLoad.allowSceneActivation = true;
    }

    // 每次換場景都 Loading 
    public static void LoadScene(EScene scene)
    {
        // recieved callback then Load to target scene
        onLoaderCallback = () =>
        {
            // 可以在背景加載場景
            ansyLoad = SceneManager.LoadSceneAsync(scene.ToString());
        };

        // loadong scene
        SceneManager.LoadScene(EScene.LoadingScene.ToString());
    }

    public static float GetLoadingProgress()
    {
        if(ansyLoad != null)
            return ansyLoad.progress;
        else
            return 1f;
    }

    public static void LoaderCallback()
    {
        // trigger after the first update
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}

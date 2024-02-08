using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerExtensions
{
    public static void LoadAndUnloadScenesAsync(this SceneManager manager, List<SceneAsset> scenesToLoad, List<SceneAsset> scenesToUnload)
    {
        foreach (SceneAsset sceneAsset in scenesToLoad)
        {
            string sceneName = sceneAsset.name;
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        foreach (SceneAsset sceneAsset in scenesToUnload)
        {
            string sceneName = sceneAsset.name;
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    private void OnEnable()
    {
        ScenesToChange.OnChangeScene += LoadAndUnload;
    }

    void LoadAndUnload(float delay, List<SceneAsset> scenesToLoad, List<SceneAsset> scenesToUnload)
    {

        StartCoroutine(LoadAndUnloadScenesCoroutine(delay, scenesToLoad, scenesToUnload));
    }

    private IEnumerator LoadAndUnloadScenesCoroutine(float delay, List<SceneAsset> scenesToLoad, List<SceneAsset> scenesToUnload)
    {
        yield return new WaitForSeconds(delay);

        foreach (var sceneAsset in scenesToUnload)
        {
            var scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            var sceneIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);
            Debug.Log(sceneIndex);
            SceneManager.UnloadSceneAsync(sceneIndex);
        }

        foreach (var sceneAsset in scenesToLoad)
        {
            var scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            var sceneIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);
            SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        }

    }

    private void OnDisable()
    {
        ScenesToChange.OnChangeScene -= LoadAndUnload;
    }
}
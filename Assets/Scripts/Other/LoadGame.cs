using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    List<SceneAsset> scenesToLoadList = new List<SceneAsset>();
    List<SceneAsset> scenesToUnloadList = new List<SceneAsset>();

    SceneManager mySeneManager = new SceneManager();

    private void OnEnable()
    {
        ScenesToChange.OnChangeScene += LoadAndUnload;
    }

    private IEnumerator DelayLoading(float delay)
    {
        yield return new WaitForSeconds(delay);
        mySeneManager.LoadAndUnloadScenesAsync(scenesToLoadList, scenesToUnloadList);

        /*foreach (var sceneAsset in scenesToLoadAssets)
        {
            var scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            var sceneIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);
            scenesToLoad.Add(SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive));
        }*/
    }

    void LoadAndUnload(float delay, List<SceneAsset> scenesToLoad, List<SceneAsset> scenesToUnload)
    {
        Debug.Log("dupa");
        StartCoroutine(LoadAndUnloadScenesCoroutine(delay, scenesToLoad, scenesToUnload));
    }

    private IEnumerator LoadAndUnloadScenesCoroutine(float delay, List<SceneAsset> scenesToLoad, List<SceneAsset> scenesToUnload)
    {
        yield return new WaitForSeconds(delay);
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

    /* private void Update()
     {
         bool allScenesLoaded = true;
         foreach (var sceneLoadOperation in scenesToLoad)
         {
             if (!sceneLoadOperation.isDone)
             {
                 allScenesLoaded = false;
                 break;
             }
         }

         if (allScenesLoaded)
         {
             SceneManager.UnloadSceneAsync(1);

             Debug.Log("All scenes loaded!");
         }
     }*/

    

    private void OnDisable()
    {
        ScenesToChange.OnChangeScene -= LoadAndUnload;
    }
}
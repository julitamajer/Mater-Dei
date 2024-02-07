using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] Image loadingBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void Start()
    {
        StartCoroutine(ProgressLoadingBar());
        StartCoroutine(DelayLoading(10f));
    }

    private IEnumerator DelayLoading(float delay)
    {
        yield return new WaitForSeconds(delay);

        scenesToLoad.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive));
    }

    private void Update()
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
    }


    private IEnumerator ProgressLoadingBar()
    {
        while (loadingBar.fillAmount < 1f)
        {
            loadingBar.fillAmount += 0.1f;

            yield return new WaitForSeconds(1f);
        }
    }
}
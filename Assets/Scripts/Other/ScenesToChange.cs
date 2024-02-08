using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScenesToChange : MonoBehaviour
{
    [SerializeField] List<SceneAsset> scenesToLoadAssets = new List<SceneAsset>();
    [SerializeField] List<SceneAsset> scenesToUnloadAssets = new List<SceneAsset>();
    [SerializeField] float delay;

    public static event System.Action<float, List<SceneAsset>, List<SceneAsset>> OnChangeScene;

    public void ChangeScenes()
    {
        OnChangeScene?.Invoke(delay, scenesToLoadAssets, scenesToUnloadAssets);
    }
}

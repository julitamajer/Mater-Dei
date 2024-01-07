using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] private GameObject playerSpawn;
    GameObject mainCamera;

    public delegate void Fade();
    public static event Fade OutFade;

    bool levelLoaded = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");

        player.transform.position = playerSpawn.transform.position;
        mainCamera.transform.position = player.transform.position;
    }
    void Update()
    {
        if (!levelLoaded)
        {
            Scene targetScene = SceneManager.GetSceneByBuildIndex(2);
            if (targetScene.IsValid() && targetScene.isLoaded)
            {
                Debug.Log("Level1 scene is fully loaded!");
                levelLoaded = true;
                OutFade?.Invoke();

            }
        }
    }


}

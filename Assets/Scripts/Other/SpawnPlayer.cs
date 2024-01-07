using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SpawnPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] private GameObject playerSpawn;
    GameObject mainCamera;
    InputActionMap actionMap;

    private DontDestroy[] dontDestroy;


    public delegate void Fade();
    public static event Fade OutFade;

    bool levelLoaded = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
        actionMap = player.GetComponent<PlayerInput>().actions.FindActionMap("Player");

        player.transform.position = playerSpawn.transform.position;
        mainCamera.transform.position = player.transform.position;
        dontDestroy = FindObjectsOfType<DontDestroy>();
    }
    private void Start()
    {
        foreach (var item in dontDestroy)
        {
            item.enabled = false;
        }
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
                actionMap.Enable();
                OutFade?.Invoke();
            }
        }
    }
}

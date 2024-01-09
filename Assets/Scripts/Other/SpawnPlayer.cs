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

    public delegate void Fade();
    public static event Fade OutFade;

    bool levelLoaded = false;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 7, false); 

        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
        actionMap = player.GetComponent<PlayerInput>().actions.FindActionMap("Player");

        player.transform.position = playerSpawn.transform.position;
        mainCamera.transform.position = player.transform.position;
    }

    private void Update()
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
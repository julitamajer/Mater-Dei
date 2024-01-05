using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] private GameObject playerSpawn;
    GameObject mainCamera;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");

        player.transform.position = playerSpawn.transform.position;
        mainCamera.transform.position = playerSpawn.transform.position;
    }
}

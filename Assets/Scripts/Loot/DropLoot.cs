using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    [SerializeField] LootType lootTypeObj;

    int objectID;
    GameObject lootPrefab;

    private void Start()
    {
        objectID = gameObject.GetInstanceID();
        lootPrefab = lootTypeObj.prefab;
    }

    private void OnEnable()
    {
        Bullet.OnLootCollision += HandleLoot;
    }

    private void HandleLoot(int objectId)
    {
        if (objectId == objectID)
        {
             Instantiate(lootPrefab, transform.position, transform.rotation);
        }
    }

    private void OnDisable()
    {
        Bullet.OnLootCollision -= HandleLoot;
    }
}



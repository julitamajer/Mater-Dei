using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public TypeOfLoot loot;


    [SerializeField] GameObject hpPrefab;
    [SerializeField] GameObject axePrefab;
    [SerializeField] GameObject moneyPrefab;


    [HideInInspector]
    public int objectID;

    private void Awake()
    {
        objectID = gameObject.GetInstanceID();
        Debug.Log(objectID);
    }

    private void OnEnable()
    {
        Bullet.OnLootCollision += HPLoot;
        Bullet.OnLootCollision += AxeLoot;
        Bullet.OnLootCollision += MoneyLoot;
    }

    private void HPLoot(int objectId)
    {
        if (objectId == objectID)
        {
            if (loot == TypeOfLoot.HP)
            {
                Instantiate(hpPrefab, transform.position, transform.rotation);

            }
        }
   
    }

    private void AxeLoot(int objectId)
    {
        if (objectId == objectID)
        {
            if (loot == TypeOfLoot.Axe)
            {
                Instantiate(axePrefab, transform.position, transform.rotation);

            }
        }
    }

    private void MoneyLoot(int objectId)
    {
        if (objectId == objectID)
        {
            if (loot == TypeOfLoot.Money)
            {
                Instantiate(moneyPrefab, transform.position, transform.rotation);

            }
        }
    }

    private void OnDisable()
    {
        Bullet.OnLootCollision -= HPLoot;
        Bullet.OnLootCollision -= AxeLoot;
        Bullet.OnLootCollision -= MoneyLoot;
    }
}

public enum TypeOfLoot
{
    HP,
    Axe,
    Money
}

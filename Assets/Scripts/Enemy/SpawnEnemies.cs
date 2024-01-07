using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject nunPrefab;
    [SerializeField] GameObject priestPrefab;
    [SerializeField] GameObject spawner;
    [SerializeField] int enemiesCount;

    [SerializeField] TypeOfEnemy enemyType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnEnemiesWithDelay());
        }
    }

    IEnumerator SpawnEnemiesWithDelay()
    {
        GameObject enemyPrefab = null;

        switch (enemyType)
        {
            case TypeOfEnemy.Nun:
                enemyPrefab = nunPrefab;
                break;
            case TypeOfEnemy.Priest:
                enemyPrefab = priestPrefab;
                break;
        }

        if (enemyPrefab != null)
        {
            for (int i = 0; i < enemiesCount; i++)
            {
                Instantiate(enemyPrefab, spawner.transform.position, spawner.transform.rotation);

                if (i == enemiesCount-1)
                    Destroy(gameObject);

                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}

public enum TypeOfEnemy
{
    Nun,
    Priest
}
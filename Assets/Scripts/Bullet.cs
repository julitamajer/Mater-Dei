using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public delegate void LootCollision(int objectId);
    public static event LootCollision OnLootCollision;

    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed *Time.deltaTime);
    
        StartCoroutine(DisapperAfterShoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            return;

        int objectId = collision.gameObject.GetInstanceID();
        Debug.Log(objectId);

        if (collision.CompareTag("Loot"))
        {
            HandleLootCollision(objectId);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Monster"))
        {
            if (collision.GetComponent<MonsterDamage>())
                collision.GetComponent<MonsterDamage>().Action();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator DisapperAfterShoot()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public static void HandleLootCollision(int objectId)
    {
        OnLootCollision?.Invoke(objectId);
    }
}

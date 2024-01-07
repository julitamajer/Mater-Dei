using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    public delegate void LootCollision(int objectId);
    public static event LootCollision OnLootCollision;

    public delegate void BossDamage();
    public static event BossDamage OnBossDamage;

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

        if (collision.CompareTag("Loot"))
        {
            HandleLootCollision(objectId);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Monster"))
        {
            HandleBossDamage();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Nun") || collision.gameObject.CompareTag("Priest"))  
        {
            DamageMonster(collision, collision.gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator DisapperAfterShoot()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

    public static void HandleLootCollision(int objectId)
    {
        OnLootCollision?.Invoke(objectId);
    }

    public static void HandleBossDamage()
    {
        OnBossDamage?.Invoke();
    }

    public static void DamageMonster(Collider2D collision, GameObject obj)
    {
        if (collision.GetComponent<MonsterDamage>())
            collision.GetComponent<MonsterDamage>().Action();
        Destroy(collision.gameObject);
        Destroy(obj);
    }
}

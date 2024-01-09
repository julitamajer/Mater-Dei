using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class Axe : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(DisapperAfterThrow());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int objectId = collision.gameObject.GetInstanceID();

        if (collision.CompareTag("Loot"))
        {
            HandleLootCollision(objectId); ; 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Nun") || collision.gameObject.CompareTag("Priest"))
        {
            DamageMonster(collision, collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Monster"))
        {
            HandleBossDamage();
            Destroy(gameObject);
        }
    }

    private IEnumerator DisapperAfterThrow()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

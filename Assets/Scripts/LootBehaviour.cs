using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class LootBehaviour : MonoBehaviour
{
    public delegate void CollectMoney();
    public static event CollectMoney collectMoney;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Money"))
        {
            collectMoney?.Invoke();
            Destroy(gameObject);
        }
    }
}

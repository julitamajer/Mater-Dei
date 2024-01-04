using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class LootBehaviour : MonoBehaviour
{
    public delegate void CollectMoney();
    public static event CollectMoney collectMoney;

    public delegate void CollectHeart();
    public static event CollectHeart collectHeart;

    public delegate void CollectAxe();
    public static event CollectAxe collectAxe;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Money"))
        {
            collectMoney?.Invoke();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Heart"))
        {
            collectHeart?.Invoke();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Axe"))
        {
            collectAxe?.Invoke();
            Destroy(gameObject);
        }
    }
}

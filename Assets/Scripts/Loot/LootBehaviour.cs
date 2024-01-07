using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;

public class LootBehaviour : MonoBehaviour
{
    public delegate void CollectMoney(int worth);
    public static event CollectMoney collectMoney;

    public delegate void CollectHeart();
    public static event CollectHeart collectHeart;

    public delegate void CollectAxe();
    public static event CollectAxe collectAxe;

    public delegate void CollectBossLoot(int worth);
    public static event CollectBossLoot collectBossLoot;

    public delegate void LastLootCollected();
    public static event LastLootCollected onLastLootCollected;

    Transform groundCheck;
    LayerMask groundLayer;

    Rigidbody2D rb;

    private void Awake()
    {
        groundCheck = transform.GetChild(0);
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsGrounded()) 
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Money"))
        {
            collectMoney?.Invoke(1000);
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

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("BossLoot"))
        {
            collectBossLoot?.Invoke(8000);
            onLastLootCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}

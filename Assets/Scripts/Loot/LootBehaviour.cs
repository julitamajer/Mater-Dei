using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bullet;
using static UnityEditor.PlayerSettings.Switch;

public class LootBehaviour : MonoBehaviour
{
    public static event System.Action<ILootable, int> OnCollectMoney;
    public static event System.Action<ILootable> OnCollectLoot;

    [SerializeField] LootType lootTypeObj;

    int lootWorth;
    Loot lootType;
    
    Transform groundCheck;
    LayerMask groundLayer;

    Rigidbody2D rb;

    private void Awake()
    {
        groundCheck = transform.GetChild(0);
        lootWorth = lootTypeObj.worth;
        lootType = lootTypeObj.type;
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
        ILootable lootable = collision.gameObject.GetComponent<ILootable>();

        if (collision.gameObject.CompareTag("Player"))
        {
            switch (lootType)
            {
                case Loot.Money:
                    OnCollectMoney?.Invoke(lootable, lootWorth);
                    break;
                case Loot.Collect:
                    OnCollectLoot?.Invoke(lootable);
                    break;
            }
            Destroy(gameObject);
        }
    }
}

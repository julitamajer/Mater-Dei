using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    [SerializeField] SpriteRenderer spriteRenderer;

    bool isFacingLeft = true;

    void Awake()
    {
        spriteRenderer.sprite = enemy.artwork;
        Physics2D.IgnoreLayerCollision(7, 7, true);

    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (isFacingLeft)
        {
            transform.Translate(Vector2.left * enemy.speed * Time.deltaTime);
        }
        else if (!isFacingLeft)
        {
            transform.Translate(Vector2.right * enemy.speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Flip();
        }
    }

    private void OnDisable()
    {
        Instantiate(enemy.artworkDamage, transform.position, Quaternion.identity);
    }
}


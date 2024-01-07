using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static PlayerCombat;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] SpriteRenderer playerSprite;

    float horizontal;
    [SerializeField] float speed = 3f;
    float jumpingPower = 7f;
    bool isFacingRight = true;
    bool isMovingToTarget = false;

    GameObject currentStairs;

    void OnEnable()
    {
        PlayerCombat.onPlayerDamage += OnDamage;
        LootBehaviour.collectBossLoot += StopMoving;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            StopCoroutine(MoveTowardsTarget(gameObject.transform.position));
        } 

        if (!isMovingToTarget)
        {
            if (!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isMovingToTarget)
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!isMovingToTarget)
        {
            if (context.performed && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (context.canceled && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

   void OnTriggerEnter2D(Collider2D collision)
   {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            if (collision.CompareTag("Start"))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

                currentStairs = collision.gameObject.transform.parent.gameObject;
                Transform end = currentStairs.transform.GetChild(1);

                StartCoroutine(MoveTowardsTarget(end.position));
            }
        }

        if (collision.CompareTag("End"))
        {
            isMovingToTarget = false;
        }
   }

    void OnDamage(GameObject tagObject)
    {
        StartCoroutine(FadeSpritePlayer());
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    IEnumerator MoveTowardsTarget(Vector2 targetPosition)
    {
        isMovingToTarget = true;
        float tolerance = 0.1f;

        while (Vector2.Distance(transform.position, targetPosition) > tolerance)
        {

            if (!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.W))
            {
                isMovingToTarget = false;
                yield break;
            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        isMovingToTarget = false;
    }

    IEnumerator FadeSpritePlayer()
    {
        Color color = playerSprite.color;
        color.a = 0.5f;
        playerSprite.color = color;

        Physics2D.IgnoreLayerCollision(3, 7, true);

        yield return new WaitForSeconds(2);

        color.a = 100f;
        playerSprite.color = color;

        Physics2D.IgnoreLayerCollision(3, 7, false);
    }

    void StopMoving()
    {
        
    }

    void OnDisable()
    {
        PlayerCombat.onPlayerDamage -= OnDamage;
        LootBehaviour.collectBossLoot -= StopMoving;
    }
}
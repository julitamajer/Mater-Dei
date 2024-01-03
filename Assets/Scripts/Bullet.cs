using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    bool isHitted;
    public delegate void LootCollision(); 
    public static event LootCollision OnLootCollision;

    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed *Time.deltaTime);
    
        StartCoroutine(DisapperAfterShoot());

       // if (isHitted )
            //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;


        if (collision.gameObject.CompareTag("Loot"))
        {
            Destroy(collision.gameObject);
            OnLootCollision?.Invoke();
        }

       // if (collision.GetComponent<MonsterDamage>())
          //  collision.GetComponent<MonsterDamage>().Action();

        //isHitted = true;
        //return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Loot"))
        {
            Destroy(collision.gameObject); 
            OnLootCollision?.Invoke(); 
        }
    }

    IEnumerator DisapperAfterShoot()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}

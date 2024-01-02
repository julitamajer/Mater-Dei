using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    bool isHitted;

    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed *Time.deltaTime);
    
        StartCoroutine(DisapperAfterShoot());

        if (isHitted )
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<MonsterDamage>())
            collision.GetComponent<MonsterDamage>().Action();

        isHitted = true;
        return;
    }

    IEnumerator DisapperAfterShoot()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

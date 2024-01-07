using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] float retreatDistance;

    [SerializeField] GameObject bullet;
    Transform player;

    [SerializeField] float startTimeBtwShots;
    float timeBtwShots;

    [SerializeField] GameObject deathPrefab;
    [SerializeField] GameObject bossLootPrefab;

    private void OnEnable()
    {
        UIBehaviour.OnBossKilled += BossDeath;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -1, 4f);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, 70, 85.50f);

            transform.position = clampedPosition;

            if (timeBtwShots <= 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    void BossDeath()
    {
        Instantiate(bossLootPrefab, transform.position, Quaternion.identity);
        Instantiate(deathPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        UIBehaviour.OnBossKilled -= BossDeath;
    }
}

    

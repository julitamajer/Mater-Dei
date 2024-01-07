using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] GameObject bossWall;
    [SerializeField] GameObject boss; 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossWall.SetActive(true);
            StartCoroutine(ShowBoss());
        }
    }

    IEnumerator ShowBoss()
    {
        yield return new WaitForSeconds(0.5f);
        boss.SetActive(true);
        gameObject.SetActive(false);
    }
}

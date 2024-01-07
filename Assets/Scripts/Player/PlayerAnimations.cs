using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            playerAnimator.SetBool("OnStairs", true);
        }

        if (collision.CompareTag("End"))
        {
            playerAnimator.SetBool("OnStairs", false);
        }


    }

}

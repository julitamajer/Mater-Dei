using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootingPoint;
    public bool canShoot = true;

    [SerializeField] GameObject axe;
    [SerializeField] float throwForce;

    [SerializeField] UIBehaviour ui;

    public delegate void PlayerDamage(GameObject tagObject);
    public static event PlayerDamage onPlayerDamage;


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!canShoot)
                return;

            GameObject bulletInst = Instantiate(bullet, shootingPoint);
            bulletInst.transform.parent = null;
        }
    }

    public void Throw(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (ui.axeCount > 0)
            {
                canShoot = false;

                ui.axeCount--;
                ui.axe.SetText("A " + ui.axeCount.ToString());

                Vector2 throwDirection;

                if (IsFlipped())
                {
                    throwDirection = new Vector2(-1f, 1f).normalized;
                }
                else
                {
                    throwDirection = new Vector2(1f, 1f).normalized;
                }

                GameObject axeInst = Instantiate(axe, shootingPoint);
                axeInst.transform.parent = null;
                axeInst.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;
            }
        }

        if(context.canceled)
        {
            canShoot= true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Nun") || collision.gameObject.CompareTag("Priest") || collision.gameObject.CompareTag("Monster"))
        {
            onPlayerDamage?.Invoke(collision.gameObject);
        }
    }

    private bool IsFlipped()
    {
        return transform.localScale.x < 0; 
    }
}

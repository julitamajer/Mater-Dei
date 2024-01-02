using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootingPoint;
    public bool canShoot = true;

    public void Shoot()
    {
        if (!canShoot)
            return;

        GameObject bulletInst = Instantiate(bullet, shootingPoint);
        bulletInst.transform.parent = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public TypeOfLoot loot;

    private void OnEnable()
    {
        Bullet.OnLootCollision += HPLoot;
        Bullet.OnLootCollision += AxeLoot;
        Bullet.OnLootCollision += MoneyLoot;
    }

    public void HPLoot()
    {
        if (loot == TypeOfLoot.HP)
        {
            Debug.Log("HP loot dropped!");
            Destroy(gameObject);
        }
    }

    public void AxeLoot()
    {

        if (loot == TypeOfLoot.Axe)
        {
            Debug.Log("Axe loot dropped!");
            Destroy(gameObject);
        }
    }

    public void MoneyLoot()
    {
        if (loot == TypeOfLoot.Money)
        {
            Debug.Log("Money loot dropped!");
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        Bullet.OnLootCollision -= HPLoot;
        Bullet.OnLootCollision -= AxeLoot;
        Bullet.OnLootCollision -= MoneyLoot;
    }


}

public enum TypeOfLoot
{
    HP,
    Axe,
    Money
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public TypeOfLoot loot;

    //[SerializeField] GameObject hpPrefab;
    //[SerializeField] GameObject axePrefab;
    [SerializeField] GameObject moneyPrefab;

    private void OnEnable()
    {
        Bullet.OnLootCollision += HPLoot;
        Bullet.OnLootCollision += AxeLoot;
        Bullet.OnLootCollision += MoneyLoot;
    }

    private void HPLoot()
    {
        if (loot == TypeOfLoot.HP)
        {
            Debug.Log("HP loot dropped!");
            Destroy(gameObject);
        }
    }

    private void AxeLoot()
    {

        if (loot == TypeOfLoot.Axe)
        {
            Debug.Log("Axe loot dropped!");
            Destroy(gameObject);
        }
    }

    private void MoneyLoot()
    {
        if (loot == TypeOfLoot.Money)
        {
            Instantiate(moneyPrefab, transform.position, transform.rotation);
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

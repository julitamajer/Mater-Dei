using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot Type", menuName = "Loot Type")]
public class LootType : ScriptableObject
{
    public Loot type;
    public int worth;
    public GameObject prefab;
}
public enum Loot
{
    Money,
    HP,
    Weapon
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILootable
{
    public void Collect(int worth, Loot lootType);
}

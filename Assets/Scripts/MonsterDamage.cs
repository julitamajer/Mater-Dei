using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MonsterDamage : MonoBehaviour
{
    public UnityEvent damage;

    public void Action()
    {
        damage?.Invoke();
    }
}

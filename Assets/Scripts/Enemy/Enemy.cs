using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemy : ScriptableObject
{
    public float speed;
    public Sprite artwork;
    public GameObject artworkDamage;
    public float damage;
}

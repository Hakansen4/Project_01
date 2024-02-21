using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Attack Object", menuName = "Enemy/AttackObject")]
public class EnemyAttackObject : ScriptableObject
{
    public float Damage;
    public float Speed;
    public float DeactivateTime;
    public Sprite Sprite;
}

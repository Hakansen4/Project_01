using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : IEnemyAttack
{
    private Transform attackPos;
    private float damage;
    private float rangeRadius;
    private LayerMask hitMasks;

    public EnemyMeleeAttack(Transform attackPos, float damage, float rangeRadius, LayerMask hitMasks)
    {
        this.attackPos = attackPos;
        this.damage = damage;
        this.rangeRadius = rangeRadius;
        this.hitMasks = hitMasks;
    }

    public void AttackAction()
    {
        var attackedObjects = Physics2D.OverlapCircleAll(attackPos.position, rangeRadius, hitMasks);
        
        foreach (var attackedObject in attackedObjects)
        {
            attackedObject.GetComponent<IHittable>().Hit(0, Vector2.zero, damage);
        }
    }
}

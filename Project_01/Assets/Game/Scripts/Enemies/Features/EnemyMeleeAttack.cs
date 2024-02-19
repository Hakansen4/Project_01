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
        Vector2 direction = Vector2.zero;
        foreach (var attackedObject in attackedObjects)
        {
            direction = (attackedObject.transform.position - attackPos.position).normalized;
            attackedObject.GetComponent<IHittable>().Hit(damage, direction, damage);
        }
    }
}

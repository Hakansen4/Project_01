using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat
{
    private IEnemyAttack attackComponent;
    public EnemyCombat(Transform enemyTransform ,Transform attackPosition, EnemyAttackObject attackObjectData)
    {
        attackComponent = new EnemyRangeAttack(attackPosition, enemyTransform, attackObjectData);
    }
    public EnemyCombat(Transform attackPos, float damage, float rangeRadius, LayerMask hitMask)
    {
        attackComponent = new EnemyMeleeAttack(attackPos, damage, rangeRadius, hitMask); 
    }
    public void Attack()
    {
        attackComponent.AttackAction();
    }
}

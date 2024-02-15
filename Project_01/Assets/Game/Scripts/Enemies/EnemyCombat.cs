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

    public void Attack()
    {
        attackComponent.AttackAction();
    }
}

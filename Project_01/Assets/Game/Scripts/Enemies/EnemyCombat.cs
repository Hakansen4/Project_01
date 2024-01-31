using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat
{
    private IEnemyAttack attackComponent;

    public EnemyCombat(Transform enemyTransform ,Transform attackPosition)
    {
        attackComponent = new EnemyRangeAttack(attackPosition, enemyTransform);
    }

    public void Attack()
    {
        attackComponent.AttackAction();
    }
}

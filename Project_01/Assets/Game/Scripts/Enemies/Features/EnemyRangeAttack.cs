using System;
using UnityEngine;

public class EnemyRangeAttack : IEnemyAttack
{
    private Transform attackPosition;
    private Transform direction;
    public EnemyRangeAttack(Transform attackPosition, Transform direction)
    {
        this.attackPosition = attackPosition;
        this.direction = direction;
    }

    public void AttackAction()
    {
        PoolManager.SetEnemyAttackObject(attackPosition.position, ((int)direction.localScale.x));
    }
}

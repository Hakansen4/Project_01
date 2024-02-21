using System;
using UnityEngine;

public class EnemyRangeAttack : IEnemyAttack
{
    private EnemyAttackObject attackObjectData;
    private Transform attackPosition;
    private Transform direction;
    public EnemyRangeAttack(Transform attackPosition, Transform direction, EnemyAttackObject attackObjectData)
    {
        this.attackPosition = attackPosition;
        this.direction = direction;
        this.attackObjectData = attackObjectData;
    }

    public void AttackAction()
    {
        PoolManager.SetEnemyAttackObject(attackPosition.position, ((int)direction.localScale.x), attackObjectData);
    }
}

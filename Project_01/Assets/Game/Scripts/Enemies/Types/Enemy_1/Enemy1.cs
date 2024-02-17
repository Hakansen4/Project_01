using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyController
{
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _leftBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _rightBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _attackPosition;

    [SerializeField] private float _radiusRange;
    [SerializeField] private LayerMask _hitMask;
    protected override void SetUpComponents()
    {
        movement = new EnemyMovement(transform, _player, _rigidbody, _speed, _leftBorder.position, _rightBorder.position);
        combat = new EnemyCombat(_attackPosition, 1, _radiusRange, _hitMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_attackPosition.position, _radiusRange);
    }
}

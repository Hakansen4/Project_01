using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : EnemyController
{
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _leftBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _rightBorder;

    protected override void SetUpComponents()
    {
        movement = new EnemyMovement(transform, _player, _rigidbody, _speed, _leftBorder.position, _rightBorder.position);
    }

    protected override void CheckStateTransition()
    {
        base.CheckStateTransition();
    }
}

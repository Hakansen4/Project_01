using Ambrosia.StateMachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class EnemyController : MonoBehaviour
{
    #region STRINGS
    private const string COMPONENTS = "COMPONENTS";
    private const string STATES = "STATES";
    #endregion
    #region States
    [FoldoutGroup(STATES), SerializeField] private StateMachine _stateMachine;
    [FoldoutGroup(STATES), SerializeField] private State _patrolState;
    [FoldoutGroup(STATES), SerializeField] private State _chaseState;
    [FoldoutGroup(STATES), SerializeField] private State _attackState;
    #endregion
    #region Components
    [FoldoutGroup(COMPONENTS), SerializeField] private Rigidbody2D _rigidbody;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _leftBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _rightBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _player;

    public EnemyMovement movement;
    #endregion
    #region Values
    [SerializeField] private float _speed;
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;

    private float range = 0;
    #endregion

    private void Awake()
    {
        movement = new EnemyMovement(transform,_player, _rigidbody, _speed, _leftBorder.position, _rightBorder.position);
    }
    private void Update()
    {
        CheckStateTransition();
    }
    private void CheckStateTransition()
    {
        range = Mathf.Abs(_player.position.x - transform.position.x);

        if(range <= _attackRange)
        {
            if(_stateMachine.CurrentState != _attackState)
                _stateMachine.TransitionTo(_attackState);
        }
        else if (range <= _chaseRange && _stateMachine.CurrentState != _attackState)
        {
            if (_stateMachine.CurrentState != _chaseState)
                _stateMachine.TransitionTo(_chaseState);
        }
        else if(range > _chaseRange && _stateMachine.CurrentState != _attackState)
        {
            if (_stateMachine.CurrentState != _patrolState)
                _stateMachine.TransitionTo(_patrolState);
        }
    }
}
public enum EnemyState
{
    Patrol
}
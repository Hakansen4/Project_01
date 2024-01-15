using Ambrosia.StateMachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class EnemyController : MonoBehaviour
{
    #region STRINGS
    private const string PATROL = "Patrol";
    private const string ATTACK = "Attack";
    private const string CHASE = "Chase";

    private const string COMPONENTS = "COMPONENTS";
    private const string STATES = "STATES";
    #endregion
    #region States
    [FoldoutGroup(STATES), SerializeField] private StateMachine _stateMachine;
    [FoldoutGroup(STATES), SerializeField] private State _patrolState;
    [FoldoutGroup(STATES), SerializeField] private State _chaseState;
    [FoldoutGroup(STATES), SerializeField] private State _attackState;
    [FoldoutGroup(STATES), SerializeField] private State _idleState;
    #endregion
    #region Components
    [FoldoutGroup(COMPONENTS), SerializeField] private Rigidbody2D _rigidbody;
    [FoldoutGroup(COMPONENTS), SerializeField] private Animator _animator;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _leftBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _rightBorder;
    [FoldoutGroup(COMPONENTS), SerializeField] private Transform _player;

    public EnemyMovement movement;
    #endregion
    #region Values
    [SerializeField] private float _speed;
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackCooldown;

    private float range = 0;
    private float attackTimer = 0;
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
            if(_stateMachine.CurrentState != _attackState   &&  Time.time - attackTimer >= _attackCooldown)
            {
                _stateMachine.TransitionTo(_attackState);
                attackTimer = Time.time;
            }
            else if(_stateMachine.CurrentState != _idleState)
            {
                _stateMachine.TransitionTo(_idleState);
            }
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
        else if(_stateMachine.CurrentState != _attackState)
        {
            if(_stateMachine.CurrentState != _idleState)
                _stateMachine.TransitionTo(_idleState);
        }
    }

    public void SetAnimation(EnemyAnims animation)
    {
        switch (animation)
        {
            case EnemyAnims.Attack:
                _animator.SetTrigger(ATTACK);
                break;

        }
    }
    public void SetAnimation(EnemyAnims animation,bool isTrue)
    {
        switch (animation)
        {
            case EnemyAnims.Attack:
                _animator.SetBool(ATTACK, isTrue);
                break;

            case EnemyAnims.Patrol:
                _animator.SetBool(PATROL, isTrue);
                break;

            case EnemyAnims.Chase:
                _animator.SetBool(CHASE, isTrue);
                break;
            case EnemyAnims.Idle:
                _animator.SetBool(PATROL, !isTrue);
                break;

        }
    }
    public void ResetStates()
    {
        if (_stateMachine.CurrentState != _idleState)
            _stateMachine.TransitionTo(_idleState);
    }
}
public enum EnemyAnims
{
    Idle,Patrol,Chase,Attack
}
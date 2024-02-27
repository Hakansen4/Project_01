using Ambrosia.StateMachine;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

public class EnemyController : MonoBehaviour
{
    #region States
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected StateMachine _stateMachine;
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected State _patrolState;
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected State _chaseState;
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected State _attackState;
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected State _idleState;
    [FoldoutGroup(GlobalStrings.STATES), SerializeField] protected State _hittedState;
    #endregion
    #region Components
    [FoldoutGroup(GlobalStrings.COMPONENTS), SerializeField] private Animator _animator;

    [FoldoutGroup(GlobalStrings.COMPONENTS), SerializeField] protected Rigidbody2D _rigidbody;
    [FoldoutGroup(GlobalStrings.COMPONENTS), SerializeField] protected Transform _player;

    public EnemyMovement movement;
    public EnemyCombat combat;
    #endregion
    #region Values
    [SerializeField] protected float _speed;
    [SerializeField] protected float _chaseRange;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _attackCooldown;

    protected float range = 0;
    protected float attackTimer = 0;
    #endregion
    private void Awake()
    {
        SetUpComponents();
    }
    private void Update()
    {
        CheckStateTransition();
    }
    protected virtual void CheckStateTransition()
    {
        range = Mathf.Abs(_player.position.x - transform.position.x);

        if (_stateMachine.CurrentState == _hittedState || _stateMachine.CurrentState == _attackState)
            return;

        if(range <= _attackRange)
        {
            if(Time.time - attackTimer >= _attackCooldown)
            {
                _stateMachine.TransitionTo(_attackState);
                attackTimer = Time.time;
            }
            else if(_stateMachine.CurrentState != _idleState)
            {
                _stateMachine.TransitionTo(_idleState);
            }
        }
        else if (range <= _chaseRange)
        {
            if (_stateMachine.CurrentState != _chaseState)
                _stateMachine.TransitionTo(_chaseState);
        }
        else if(range > _chaseRange)
        {
            if (_stateMachine.CurrentState != _patrolState)
                _stateMachine.TransitionTo(_patrolState);
        }
        else
        {
            if(_stateMachine.CurrentState != _idleState)
                _stateMachine.TransitionTo(_idleState);
        }
    }
    protected virtual void SetUpComponents()
    {

    }
    public void SetAnimation(EnemyAnims animation)
    {
        switch (animation)
        {
            case EnemyAnims.Attack:
                _animator.SetTrigger(GlobalStrings.E_ATTACK);
                break;

        }
    }
    public void SetAnimation(EnemyAnims animation,bool isTrue)
    {
        switch (animation)
        {
            case EnemyAnims.Attack:
                _animator.SetBool(GlobalStrings.E_ATTACK, isTrue);
                break;

            case EnemyAnims.Patrol:
                _animator.SetBool(GlobalStrings.E_PATROL, isTrue);
                break;

            case EnemyAnims.Chase:
                _animator.SetBool(GlobalStrings.E_CHASE, isTrue);
                break;
            case EnemyAnims.Idle:
                _animator.SetBool(GlobalStrings.E_PATROL, !isTrue);
                break;
            case EnemyAnims.Hitted:
                _animator.SetBool(GlobalStrings.E_HITTED, isTrue);
                break;

        }
    }
    public void ResetStates()
    {
        if (_stateMachine.CurrentState != _idleState)
            _stateMachine.TransitionTo(_idleState);
    }
    public void HittedState()
    {
        if (_stateMachine.CurrentState != _hittedState)
            _stateMachine.TransitionTo(_hittedState);
    }
    public void Push(Vector2 value)
    {
        _rigidbody.AddForce(value);
    }
    public void SetVelocity(Vector2 value)
    {
        _rigidbody.velocity = value;
    }
}
public enum EnemyAnims
{
    Idle,Patrol,Chase,Attack,Hitted
}
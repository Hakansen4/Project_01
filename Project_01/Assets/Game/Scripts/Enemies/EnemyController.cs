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
    private const string HITTED = "Hitted";

    protected const string COMPONENTS = "COMPONENTS";
    private const string STATES = "STATES";
    #endregion
    #region States
    [FoldoutGroup(STATES), SerializeField] protected StateMachine _stateMachine;
    [FoldoutGroup(STATES), SerializeField] protected State _patrolState;
    [FoldoutGroup(STATES), SerializeField] protected State _chaseState;
    [FoldoutGroup(STATES), SerializeField] protected State _attackState;
    [FoldoutGroup(STATES), SerializeField] protected State _idleState;
    [FoldoutGroup(STATES), SerializeField] protected State _hittedState;
    #endregion
    #region Components
    [FoldoutGroup(COMPONENTS), SerializeField] private Animator _animator;

    [FoldoutGroup(COMPONENTS), SerializeField] protected Rigidbody2D _rigidbody;
    [FoldoutGroup(COMPONENTS), SerializeField] protected Transform _player;

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
            case EnemyAnims.Hitted:
                _animator.SetBool(HITTED, isTrue);
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
}
public enum EnemyAnims
{
    Idle,Patrol,Chase,Attack,Hitted
}
using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region STRINGS
    #endregion
    #region States
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private State _patrolState;
    [SerializeField] private State _chaseState;
    #endregion
    #region Components
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _player;

    public EnemyMovement movement;
    #endregion
    #region States
    [SerializeField] private float _speed;
    [SerializeField] private float _chaseRange;
    #endregion

    private void Awake()
    {
        movement = new EnemyMovement(transform, _rigidbody, _speed, _leftBorder.position, _rightBorder.position);
    }
    private void Update()
    {
        CheckStateTransition();
    }
    private void CheckStateTransition()
    {
        if(_player.position.x - transform.position.x >= -_chaseRange &&  _stateMachine.CurrentState != _chaseState)
        {
            _stateMachine.TransitionTo(_chaseState);
        }
        else if(_stateMachine.CurrentState != _patrolState)
        {
            _stateMachine.TransitionTo(_patrolState);
        }
    }
    private void ChangeState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Patrol:
                _stateMachine.TransitionTo(_patrolState);
                break;
        }
    }
}
public enum EnemyState
{
    Patrol
}
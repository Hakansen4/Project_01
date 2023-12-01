using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string RUN = "Run";

    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private State _idleState;
    [SerializeField] private State _moveState;

    [SerializeField] private float _runningSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private Animator _animator;

    public PlayerMovement Movement;
    private void Awake()
    {
        Movement = new PlayerMovement(_runningSpeed, _rigidbody, transform);
    }
    private void Update()
    {
        if (InputManager.CheckMoveInput())
            ChangeState(PlayerState.Move);
        else
            ChangeState(PlayerState.Idle);
    }
    private void ChangeState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                if (CheckStateTransition(state))
                    _stateMachine.TransitionTo(_idleState);
                break;
            case PlayerState.Move:
                if(CheckStateTransition(state))
                    _stateMachine.TransitionTo(_moveState);
                break;
        }
    }

    private bool CheckStateTransition(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.Idle:
                if(_stateMachine.CurrentState != _idleState)
                    return true;
                break;
            case PlayerState.Move:
                if(_stateMachine.CurrentState != _moveState)
                    return true;
                break;
        }
        return false;
    }

    public void SetAnimation(PLayerAnims animation,bool isTrue)
    {
        switch(animation)
        {
            case PLayerAnims.Run:
                _animator.SetBool(RUN, isTrue);
                break;
        }
    }
}
public enum PlayerState
{
    Idle,Move
}
public enum PLayerAnims
{
    Run
}
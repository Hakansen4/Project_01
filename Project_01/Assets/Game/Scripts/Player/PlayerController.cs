using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string RUN = "Run";
    private const string JUMP = "Jump";
    private const string JUMPT = "JumpT";

    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private State _idleState;
    [SerializeField] private State _moveState;
    [SerializeField] private State _jumpState;

    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private Animator _animator;

    public PlayerMovement Movement;
    private void Awake()
    {
        Movement = new PlayerMovement(_runningSpeed, _rigidbody, transform, _jumpPower);
    }
    private void Update()
    {
        if (InputManager.CheckJumpInput())
            ChangeState(PlayerState.Jump);

        if (InputManager.CheckMoveInput())
            ChangeState(PlayerState.Move);
        else
            ChangeState(PlayerState.Idle);
    }
    public void ResetState()
    {
        if (_stateMachine.CurrentState != _idleState)
            _stateMachine.TransitionTo(_idleState);
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
            case PlayerState.Jump:
                if(CheckStateTransition(state))
                    _stateMachine.TransitionTo(_jumpState);
                break;
        }
    }

    private bool CheckStateTransition(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.Idle:
                if(_stateMachine.CurrentState != _idleState && _stateMachine.CurrentState != _jumpState)
                    return true;
                break;
            case PlayerState.Move:
                if (_stateMachine.CurrentState != _moveState && _stateMachine.CurrentState != _jumpState)
                    return true;
                break;
            case PlayerState.Jump:
                if(_stateMachine.CurrentState != _jumpState)
                    return true;
                break;
        }
        return false;
    }
    public void SetAnimation(PLayerAnims animation)
    {
        switch (animation)
        {
            case PLayerAnims.Jump:
                _animator.SetTrigger(JUMPT);
                _animator.SetBool(JUMP, true);
                break;
        }
    }

    public void SetAnimation(PLayerAnims animation,bool isTrue)
    {
        switch(animation)
        {
            case PLayerAnims.Run:
                _animator.SetBool(RUN, isTrue);
                break;
            case PLayerAnims.Jump:
                _animator.SetBool(JUMP, isTrue);
                break;
        }
    }
}
public enum PlayerState
{
    Idle,Move,Jump
}
public enum PLayerAnims
{
    Run,Jump
}
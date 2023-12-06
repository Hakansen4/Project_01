using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerController : MonoBehaviour
{
    #region STRINGS
    private const string RUN = "Run";
    private const string JUMP = "Jump";
    private const string JUMPT = "JumpT";
    private const string EXPLODE = "Explode";

    private const string STATES = "STATES";
    private const string COMPONENTS = "COMPONENTS";
    #endregion
    #region States
    [FoldoutGroup(STATES), SerializeField] private StateMachine _stateMachine;
    [FoldoutGroup(STATES), SerializeField] private State _idleState;
    [FoldoutGroup(STATES), SerializeField] private State _moveState;
    [FoldoutGroup(STATES), SerializeField] private State _jumpState;
    [FoldoutGroup(STATES), SerializeField] private State _combatState;
    #endregion
    #region Components
    [FoldoutGroup(COMPONENTS), SerializeField] private Rigidbody2D _rigidbody;
    [FoldoutGroup(COMPONENTS), SerializeField] private Animator _animator;
    #endregion
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _attackCooldown;

    public PlayerMovement Movement;
    public PlayerCombat Combat;
    private void Awake()
    {
        Movement = new PlayerMovement(_runningSpeed, _rigidbody, transform, _jumpPower);
        Combat = new PlayerCombat(_attackPower, _attackCooldown, _rigidbody);
    }
    private void Update()
    {
        if (InputManager.CheckCombatInput())
            ChangeState(PlayerState.Combat);

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
            case PlayerState.Combat:
                if (CheckStateTransition(state))
                    _stateMachine.TransitionTo(_combatState);
                break;
        }
    }

    private bool CheckStateTransition(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.Idle:
                if(_stateMachine.CurrentState != _idleState && _stateMachine.CurrentState != _jumpState &&
                    _stateMachine.CurrentState != _combatState)
                    return true;
                break;
            case PlayerState.Move:
                if (_stateMachine.CurrentState != _moveState && _stateMachine.CurrentState != _jumpState &&
                    _stateMachine.CurrentState != _combatState)
                    return true;
                break;
            case PlayerState.Jump:
                if(_stateMachine.CurrentState != _jumpState &&  _stateMachine.CurrentState != _combatState)
                    return true;
                break;
            case PlayerState.Combat:
                if(_stateMachine.CurrentState != _combatState && Combat.CanExplode())
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
            case PLayerAnims.Combat:
                _animator.SetTrigger(EXPLODE);
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
    Idle,Move,Jump,Combat
}
public enum PLayerAnims
{
    Run,Jump,Combat
}
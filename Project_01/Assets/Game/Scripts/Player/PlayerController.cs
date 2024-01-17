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
    private const string PUSH = "Push";
    private const string PULL = "Pull";
    private const string WALLSLIDE = "WallSlide";
    private const string WALLSLIDET = "WallSlideT";
    private const string LEDGECLIMB = "LedgeClimb";

    private const string STATES = "STATES";
    private const string COMPONENTS = "COMPONENTS";
    #endregion
    #region States
    [FoldoutGroup(STATES), SerializeField] private StateMachine _stateMachine;
    [FoldoutGroup(STATES), SerializeField] private State _idleState;
    [FoldoutGroup(STATES), SerializeField] private State _moveState;
    [FoldoutGroup(STATES), SerializeField] private State _jumpState;
    [FoldoutGroup(STATES), SerializeField] private State _combatState;
    [FoldoutGroup(STATES), SerializeField] private State _pushState;
    [FoldoutGroup(STATES), SerializeField] private State _wallSlideState;
    [FoldoutGroup(STATES), SerializeField] private State _ledgeClimbState;
    #endregion
    #region Components
    [FoldoutGroup(COMPONENTS), SerializeField] private Rigidbody2D _rigidbody;
    [FoldoutGroup(COMPONENTS), SerializeField] private Animator _animator;

    [FoldoutGroup(COMPONENTS)]  public PlayerCollider Collide;
    [FoldoutGroup(COMPONENTS)]  public LedgeDetection LedgeDetect;
    [FoldoutGroup(COMPONENTS)]  public PlayerMovement Movement;
    [FoldoutGroup(COMPONENTS)]  public PlayerCombat Combat;
    [FoldoutGroup(COMPONENTS)]  public ExplodeHitDetection hitDetect;
    #endregion
    #region Stats
    private const float GRAVITY = 1.5f;

    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _attackPower;
    [SerializeField] private float _attackCooldown;

    #endregion

    private bool canWallSlide = true;
    private void Awake()
    {
        Movement = new PlayerMovement(_runningSpeed, _rigidbody, transform, _jumpPower);
        Combat = new PlayerCombat(_attackPower, _attackCooldown, _rigidbody);
    }
    private void Update()
    {
        if (LedgeDetect.CheckLedge())
            ChangeState(PlayerState.LedgeClimb);

        if (InputManager.CheckJumpInput())
            ChangeState(PlayerState.Jump);

        else if (Collide.CheckWallCollide()  &&  !Collide.CheckGrounded())
            ChangeState(PlayerState.WallSlide);

        if (InputManager.CheckPushInput()   &&  Collide.CheckPushObjectCollide())
            ChangeState(PlayerState.Push);

        if (InputManager.CheckCombatInput())
            ChangeState(PlayerState.Combat);

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
            case PlayerState.Push:
                if(CheckStateTransition(state))
                    _stateMachine.TransitionTo(_pushState);
                break;
            case PlayerState.WallSlide:
                if (CheckStateTransition(state))
                    _stateMachine.TransitionTo(_wallSlideState);
                break;
            case PlayerState.LedgeClimb:
                if (CheckStateTransition(state))
                    _stateMachine.TransitionTo(_ledgeClimbState);
                break;
        }
    }

    private bool CheckStateTransition(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.Idle:
                if(_stateMachine.CurrentState != _idleState && _stateMachine.CurrentState != _jumpState &&
                    _stateMachine.CurrentState != _combatState && _stateMachine.CurrentState != _pushState &&
                    _stateMachine.CurrentState != _wallSlideState && _stateMachine.CurrentState != _ledgeClimbState)
                    return true;
                break;
            case PlayerState.Move:
                if (_stateMachine.CurrentState != _moveState && _stateMachine.CurrentState != _jumpState &&
                    _stateMachine.CurrentState != _combatState && _stateMachine.CurrentState != _pushState &&
                    _stateMachine.CurrentState != _wallSlideState && _stateMachine.CurrentState != _ledgeClimbState)
                    return true;
                break;
            case PlayerState.Jump:
                if(_stateMachine.CurrentState != _jumpState &&  _stateMachine.CurrentState != _combatState &&
                    _stateMachine.CurrentState != _pushState && _stateMachine.CurrentState != _ledgeClimbState)
                    return true;
                break;
            case PlayerState.Combat:
                if(_stateMachine.CurrentState != _combatState && Combat.CanExplode() && _stateMachine.CurrentState != _pushState &&
                    _stateMachine.CurrentState != _wallSlideState && _stateMachine.CurrentState != _ledgeClimbState)
                    return true;
                break;
            case PlayerState.Push:
                if(_stateMachine.CurrentState == _idleState || _stateMachine.CurrentState == _moveState)
                    return true;
                break;
            case PlayerState.WallSlide:
                if (_stateMachine.CurrentState != _wallSlideState && _stateMachine.CurrentState != _combatState &&
                    _stateMachine.CurrentState != _pushState && _stateMachine.CurrentState != _ledgeClimbState &&
                    canWallSlide)
                    return true;
                break;
            case PlayerState.LedgeClimb:
                if(_stateMachine.CurrentState != _ledgeClimbState && _stateMachine.CurrentState != _pushState)
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
            case PLayerAnims.WallSlide:
                _animator.SetTrigger(WALLSLIDET);
                _animator.SetBool(WALLSLIDE, true);
                break;
            case PLayerAnims.LedgeClimb:
                _animator.SetTrigger(LEDGECLIMB);
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
            case PLayerAnims.Push:
                _animator.SetBool(PUSH, isTrue);
                break;
            case PLayerAnims.Pull:
                _animator.SetBool(PULL, isTrue);
                break;
            case PLayerAnims.WallSlide:
                _animator.SetBool(WALLSLIDE, isTrue);
                break;
        }
    }
    public void SetAnimationLayer(int index,float weight)
    {
        _animator.SetLayerWeight(index, weight);
    }

    public void SetGravity(float value)
    {
        _rigidbody.gravityScale = value;
    }
    public void ResetGravity()
    {
        _rigidbody.gravityScale = GRAVITY;
    }
    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    
    public void WallToJump()
    {
        StopCoroutine(ResetWallSlide());
        _stateMachine.TransitionTo(_jumpState);
        canWallSlide = false;
        StartCoroutine(ResetWallSlide());
    }
    private IEnumerator ResetWallSlide()
    {
        yield return new WaitForSeconds(1.0f);
        canWallSlide = true;
    }
}
public enum PlayerState
{
    Idle,Move,Jump,Combat,Push,WallSlide,LedgeClimb
}
public enum PLayerAnims
{
    Run,Jump,Combat,Push,Pull,WallSlide,LedgeClimb
}
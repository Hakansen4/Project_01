using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class PushP : State
{
    [SerializeField] private PlayerController _controller;

    private float pushSpeed = 0.0f;
    private const int animationLayer = 1;
    private const int animationWeight = 1;
    private float direction;
    protected override void OnEnter()
    {
        pushSpeed = _controller.Collide.pushObject.GetPushSpeed();
        _controller.SetAnimationLayer(animationLayer, animationWeight);
    }

    protected override void OnExit()
    {
        _controller.SetAnimationLayer(animationLayer, 0);
        _controller.Collide.pushObject.StopPush();
    }
    private void FixedUpdate()
    {
        CheckMovement();
        CheckPushModeExit();
    }
    private void CheckPushModeExit()
    {
        if (InputManager.CheckBackInput())
        {
            _controller.ResetState();
        }
    }
    private void CheckMovement()
    {
        direction = _controller.Movement.PushMove(pushSpeed);
        if (direction == 0)
            SetAnimations(false, false);
        else if (direction > 0)
            SetAnimations(true, false);
        else
            SetAnimations(false, true);

    }
    private void SetAnimations(bool Push,bool Pull)
    {
        _controller.SetAnimation(PLayerAnims.Push, Push);
        _controller.SetAnimation(PLayerAnims.Pull, Pull);
    }
}

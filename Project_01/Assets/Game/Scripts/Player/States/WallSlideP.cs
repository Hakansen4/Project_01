using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
using Ambrosia.EventBus;
using System;

public class WallSlideP : State
{
    [SerializeField] private PlayerController _controller;

    private float GravityValue = 0.5f;
    protected override void OnEnter()
    {
        _controller.ResetVelocity();
        _controller.SetAnimation(PLayerAnims.WallSlide);
        _controller.SetGravity(GravityValue);
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(PLayerAnims.WallSlide, false);
        _controller.ResetGravity();
    }
    private void FixedUpdate()
    {
        CheckGroundHit();
    }
    private void CheckGroundHit()
    {
        if (InputManager.CheckJumpInput())
            _controller.WallToJump();

        if (_controller.Collide.CheckGrounded() || !_controller.Collide.CheckWallCollide())
            _controller.ResetState();
    }
}

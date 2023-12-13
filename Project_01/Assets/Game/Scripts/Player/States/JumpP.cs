using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;
using System;

public class JumpP : State
{
    [SerializeField] PlayerController _controller;

    private const float checkTimer = 0.1f;
    private float timer;
    protected override void OnEnter()
    {
        Debug.Log("Player on Jump State");
        timer = 0;
        _controller.Movement.Jump();
        _controller.SetAnimation(PLayerAnims.Jump);
        //CheckLedgeClimb();
    }
    protected override void OnExit()
    {
        _controller.SetAnimation(PLayerAnims.Jump, false);
    }
    
    private void FixedUpdate()
    {
        //CheckLedgeClimb();
        _controller.Movement.Run();
        CheckGroundHit();
        CheckWallHit();
    }
    //private void CheckLedgeClimb()
    //{
    //    if (_controller.LedgeDetect.CheckLedge())
    //        _controller.TransitionToLedgeClimb();
    //}
    private void CheckWallHit()
    {
        if (_controller.Collide.CheckWallCollide() && !_controller.Collide.CheckGrounded()  &&  timer > checkTimer)
            _controller.TransitionToWallSlide();
    }
    private void CheckGroundHit()
    {
        timer += Time.deltaTime;
        if (_controller.Collide.CheckGrounded() && timer > checkTimer)
            _controller.ResetState();
    }
}

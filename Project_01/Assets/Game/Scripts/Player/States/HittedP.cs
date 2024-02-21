using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittedP : State
{
    [SerializeField] private PlayerController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(PLayerAnims.Hitted);
        _controller.ResetVelocity();
        _controller.Movement.HittedMove(_controller.Collide.CheckHittedFromLeft());
    }

    protected override void OnExit()
    {

    }
    public void ENDSTATE()
    {
        _controller.ResetState();
    }
}

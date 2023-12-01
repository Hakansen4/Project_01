using Ambrosia.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : State
{
    [SerializeField] PlayerController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(PLayerAnims.Run, true);
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(PLayerAnims.Run, false);
    }

    private void FixedUpdate()
    {
        _controller.Movement.Run();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class IdleE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(EnemyAnims.Idle, true);
        _controller.movement.Stop();
    }

    protected override void OnExit()
    {
    }
}

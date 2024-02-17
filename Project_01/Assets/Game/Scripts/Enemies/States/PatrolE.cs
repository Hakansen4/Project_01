using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class PatrolE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(EnemyAnims.Patrol, true);
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(EnemyAnims.Patrol, false);
    }
    private void FixedUpdate()
    {
        _controller.movement.PatrolMove();
    }
}

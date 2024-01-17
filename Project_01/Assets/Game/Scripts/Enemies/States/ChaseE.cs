using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class ChaseE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(EnemyAnims.Patrol, true);
        _controller.SetAnimation(EnemyAnims.Chase, true);
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(EnemyAnims.Chase, false);
    }
    private void FixedUpdate()
    {
        _controller.movement.ChaseMove();
    }
}

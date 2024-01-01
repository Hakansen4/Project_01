using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class PatrolE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {

    }

    protected override void OnExit()
    {

    }
    private void FixedUpdate()
    {
        _controller.movement.PatrolMove();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
using System;

public class AttackE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        _controller.movement.Stop();
    }

    protected override void OnExit()
    {
        Debug.Log(_controller.transform.position.x);
    }
}

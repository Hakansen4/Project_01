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
        _controller.SetAnimation(EnemyAnims.Attack);
    }

    protected override void OnExit()
    {
    }

    //Calling from animation
    public void AttackFinished()
    {
        _controller.ResetStates();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class ChaseE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        Debug.Log("AAA");
    }

    protected override void OnExit()
    {
    }
    private void Update()
    {
        _controller.movement.ChaseMove();
    }
}

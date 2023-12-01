using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
using System;

public class IdleP : State
{
    protected override void OnEnter()
    {
        Debug.Log("Player on Idle State");
    }

    protected override void OnExit()
    {

    }
}

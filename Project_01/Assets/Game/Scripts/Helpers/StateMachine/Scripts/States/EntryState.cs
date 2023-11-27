using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class EntryState : State
{
    protected override void OnEnter()
    {
        
    }

    protected override void OnExit()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StateMachine.TransitionToNextState();
        }
    }
}

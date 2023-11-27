using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class GamePlayState : State
{
    protected override void OnEnter()
    {
        Debug.Log("Gameplay State");
    }

    protected override void OnExit()
    {
        
    }
}

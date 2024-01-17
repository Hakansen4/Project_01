using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class HittedE : State
{
    [SerializeField] private EnemyController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(EnemyAnims.Hitted, true);
        StartCoroutine(EndState());
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(EnemyAnims.Hitted, false);
    }

    private IEnumerator EndState()
    {
        yield return new WaitForSeconds(1);
        _controller.ResetStates();
    }
}

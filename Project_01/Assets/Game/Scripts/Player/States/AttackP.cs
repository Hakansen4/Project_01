using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
public class AttackP : State
{
    [SerializeField] private PlayerController _controller;
    protected override void OnEnter()
    {
        Debug.Log("Player on Attack State");
        _controller.SetAnimation(PLayerAnims.Combat);
    }

    protected override void OnExit()
    {
    }

    //Calling from animation
    public void EXPLODE()
    {
        _controller.Combat.Explode();
    }

    //Calling from animation
    public void AttackFinished()
    {
        _controller.ResetState();
    }
}

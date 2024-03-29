using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
public class AttackP : State
{
    [SerializeField] private PlayerController _controller;
    protected override void OnEnter()
    {
        _controller.SetAnimation(PLayerAnims.Combat);
    }

    protected override void OnExit()
    {
    }

    //Calling from animation
    public void EXPLODE()
    {
        _controller.Combat.Explode();
        _controller.Combat.PushEnemies(_controller.hitDetect.GetHittedEnemies());
    }

    //Calling from animation
    public void AttackFinished()
    {
        _controller.ResetState();
    }
}

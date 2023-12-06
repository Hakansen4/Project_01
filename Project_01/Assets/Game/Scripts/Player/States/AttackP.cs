using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;
public class AttackP : State
{
    [SerializeField] private PlayerController controller;
    protected override void OnEnter()
    {
        Debug.Log("Player on Attack State");
        controller.SetAnimation(PLayerAnims.Combat);
    }

    protected override void OnExit()
    {
    }

    //Calling from animation
    public void EXPLODE()
    {
        controller.Combat.Explode();
    }

    //Calling from animation
    public void AttackFinished()
    {
        controller.ResetState();
    }
}

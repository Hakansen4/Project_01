using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class PushP : State
{
    [SerializeField] private PlayerController controller;
    private const int animationLayer = 1;
    private const int animationWeight = 1;
    private float direction;
    protected override void OnEnter()
    {
        controller.SetAnimationLayer(animationLayer, animationWeight);
    }

    protected override void OnExit()
    {
        controller.SetAnimationLayer(animationLayer, 0);
    }
    private void FixedUpdate()
    {
        CheckMovement();
        CheckPushModeExit();
    }
    private void CheckPushModeExit()
    {
        if (InputManager.CheckBackInput())
        {
            controller.ResetState();
        }
    }
    private void CheckMovement()
    {
        direction = controller.Movement.PushMove();
        if (direction == 0)
            SetAnimations(false, false);
        else if (direction > 0)
            SetAnimations(true, false);
        else
            SetAnimations(false, true);

    }
    private void SetAnimations(bool Push,bool Pull)
    {
        controller.SetAnimation(PLayerAnims.Push, Push);
        controller.SetAnimation(PLayerAnims.Pull, Pull);
    }
}

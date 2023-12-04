using Ambrosia.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpP : State
{
    private const string GROUND = "Ground";

    [SerializeField] PlayerController _controller;
    protected override void OnEnter()
    {
        Debug.Log("Player on Jump State");
        _controller.Movement.Jump();
        _controller.SetAnimation(PLayerAnims.Jump);
    }

    protected override void OnExit()
    {
        _controller.SetAnimation(PLayerAnims.Jump, false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
            _controller.ResetState();
    }
    private void FixedUpdate()
    {
        _controller.Movement.Run();
    }
}

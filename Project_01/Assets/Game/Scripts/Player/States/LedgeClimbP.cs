using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.StateMachine;

public class LedgeClimbP : State
{
    [SerializeField] PlayerController _controller;

    [SerializeField] private Vector3 _startOffset;
    [SerializeField] private Vector3 _endOffset;

    private Vector3 startingVec;
    private Vector3 endingVec;
    protected override void OnEnter()
    {
        startingVec = new Vector2(_startOffset.x * _controller.transform.localScale.x, _startOffset.y);
        endingVec = new Vector3(_endOffset.x * _controller.transform.localScale.x, _endOffset.y);

        _controller.transform.position += startingVec;
        _controller.ResetVelocity();
        _controller.SetGravity(0);
        _controller.SetAnimation(PLayerAnims.LedgeClimb);
    }

    protected override void OnExit()
    {
        _controller.SetGravity(1.5f);
        _controller.transform.position += endingVec;
    }

    public void STOPLEDGECLIMB()
    {
        _controller.ResetState();
    }
}

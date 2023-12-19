using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectController : MonoBehaviour, IPushable
{
    [SerializeField] private float _pushSpeed;

    [SerializeField] private Rigidbody2D _rb;

    private bool canMove = false;
    public float GetPushSpeed()
    {
        return _pushSpeed;
    }

    public void StartPush()
    {
        canMove = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void StopPush()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        canMove = false;
    }
    private void FixedUpdate()
    {
        if (!canMove)
            return;

        Move();
    }
    private void Move()
    {
        float horizontalValue = InputManager.GetHoriontalValue();

        _rb.velocity = new Vector2(horizontalValue * _pushSpeed * Time.fixedDeltaTime, _rb.velocity.y);
    }
}

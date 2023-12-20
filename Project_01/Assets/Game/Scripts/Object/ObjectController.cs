using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectController : MonoBehaviour, IPushable
{
    [SerializeField] private float _pushSpeed;

    [SerializeField] private Rigidbody2D _rb;

    private ObjectMovement movement;

    private void Awake()
    {
        movement = new ObjectMovement(_pushSpeed,_rb);
    }
    private void FixedUpdate()
    {
        movement.MoveWorks();
    }
    public float GetPushSpeed()
    {
        return movement.GetPushSpeed();
    }

    public void StartPush()
    {
        movement.StartPush();
    }

    public void StopPush()
    {
        movement.StopPush();
    }
}

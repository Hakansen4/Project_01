using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectController : MonoBehaviour, IPushable
{
    [SerializeField] private float _pushSpeed;

    [SerializeField] private Rigidbody2D _rb;

    private ObjectMovement movement;

    private List<ObjectController> chainObjects;

    private void Awake()
    {
        chainObjects = GetComponentsInChildren<ObjectController>().ToList();
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
        StartChainObjects();
    }

    public void StopPush()
    {
        movement.StopPush();
        StopChainObjects();
    }
    public void StartChainPush(float Speed)
    {
        movement.ChainPush(Speed);
    }
    public void StopChainPush()
    {
        movement.StopPush();
    }
    private void StartChainObjects()
    {
        foreach(var obj in chainObjects)
        {
            obj.StartChainPush(GetPushSpeed());
        }
    }
    private void StopChainObjects()
    {
        foreach (var obj in chainObjects)
        {
            obj.StopChainPush();
        }
    }
}

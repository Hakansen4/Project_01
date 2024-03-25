using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyController _controller;
    public void Hit(float power, Vector2 direction, float damage)
    {
        _controller.movement.Push(direction * power);
        _controller.HittedState();
    }

    public void PushReverse(Vector3 objectPosition)
    {
        _controller.movement.SetVelocity(-1 * _controller.movement.CurrentVelocity());
        _controller.HittedState();
    }
}

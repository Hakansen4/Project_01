using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyController _controller;
    public void Hit(float power, Vector2 direction)
    {
        _controller.Push(direction * power);
        _controller.HittedState();
    }
}

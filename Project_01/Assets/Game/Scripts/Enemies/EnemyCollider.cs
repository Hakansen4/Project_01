using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyController _controller;
    public void Hit(HitType type, float value)
    {
        switch (type)
        {
            case HitType.Push:
                _controller.Push(new Vector2(value, value));
                _controller.HittedState();
                break;
            case HitType.Damage:
                break;
            default:
                break;
        }
    }
}

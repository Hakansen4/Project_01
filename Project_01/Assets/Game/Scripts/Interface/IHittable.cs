using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public void Hit(float power, Vector2 direction , float damage);
    public void PushReverse(Vector3 objectPosition);
}

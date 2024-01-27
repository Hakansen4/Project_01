using UnityEngine;

public interface IHittable
{
    void Hit(float power, Vector2 direction);
}

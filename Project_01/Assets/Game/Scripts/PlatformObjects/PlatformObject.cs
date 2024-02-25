using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformObject : MonoBehaviour
{
    protected abstract void React(IHittable hitObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitObject = collision.gameObject.GetComponent<IHittable>();
        if(hitObject is IHittable)
            React(hitObject);
    }
}

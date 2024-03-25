using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformObject : MonoBehaviour
{
    [SerializeField] protected LayerMask _mask;
    protected abstract void React(IHittable hitObject);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((_mask.value & 1 << collision.gameObject.layer) > 0)
            React(collision.GetComponent<IHittable>());
    }
}
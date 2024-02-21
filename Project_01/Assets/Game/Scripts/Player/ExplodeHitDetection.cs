using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeHitDetection : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;


    public Collider2D[] GetHittedEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

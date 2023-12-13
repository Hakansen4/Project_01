using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    private const string GROUND = "Ground";

    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private bool canDetect = false;

    public bool CheckLedge()
    {
        if (canDetect)
            return Physics2D.OverlapCircle(transform.position, _radius, _layerMask);

        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(GROUND))
            canDetect = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(GROUND))
            canDetect = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}

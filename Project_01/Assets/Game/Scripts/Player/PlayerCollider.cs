using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ambrosia.EventBus;

public class PlayerCollider : MonoBehaviour, IHittable
{
    private const string GROUND = "Ground";
    private const string WALL = "Wall";

    [SerializeField] private PlayerController _controller;

    private bool grounded = false;
    private bool wallCollide = false;
    private bool isPushing = false;
    private bool isHittedFromLeft = false;

    [HideInInspector] public IPushable pushObject = null;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IPushable>() != null &&
                transform.position.y < collision.gameObject.transform.position.y)
        {
            pushObject = collision.gameObject.GetComponent<IPushable>();
        }
        else if(!isPushing)
            pushObject = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            grounded = true;
        }
        else if(collision.gameObject.CompareTag(WALL))
        {
            wallCollide = true;
        }
        else if(collision.gameObject.GetComponent<IPushable>() != null)
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            grounded = false;
        }
        else if (collision.gameObject.CompareTag(WALL))
        {
            wallCollide = false;
        }
        else if(collision.gameObject.GetComponent<IPushable>() != null)
        {
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedObject = collision.GetComponent<E_AttackObject>();
        if (collidedObject)
        {
            _controller.GotHit(collidedObject.GetDamage());
            collidedObject.DestroyObject();
            if (collision.gameObject.transform.position.x > transform.position.x)
                isHittedFromLeft = false;
            else
                isHittedFromLeft = true;
        }
    }
    public void PushOver()
    {
        isPushing = false;
        pushObject = null;
    }
    public bool CheckPushObjectCollide()
    {
        if(pushObject != null)
        {
            pushObject.StartPush();
            isPushing = true;
            return true;
        }
        isPushing = false;
        return false;
    }
    public bool CheckGrounded()
    {
        return grounded;
    }
    public bool CheckWallCollide()
    {
        return wallCollide;
    }
    public bool CheckHittedFromLeft()
    {
        return isHittedFromLeft;
    }

    public void Hit(float power, Vector2 direction, float damage)
    {
        if (direction.x > 0)
            isHittedFromLeft = true;
        else
            isHittedFromLeft = false;


        _controller.GotHit(damage);
    }
}

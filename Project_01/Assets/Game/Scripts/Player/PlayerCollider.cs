using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private const string GROUND = "Ground";
    private const string WALL = "Wall";

    private bool grounded = false;
    private bool wallCollide = false;
    private bool isPushing = false;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private const string GROUND = "Ground";
    private const string WALL = "Wall";

    private bool grounded = false;
    private bool wallCollide = false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            grounded = true;
        }
        if(collision.gameObject.CompareTag(WALL))
        {
            wallCollide = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            grounded = false;
        }
        if (collision.gameObject.CompareTag(WALL))
        {
            wallCollide = false;
        }
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

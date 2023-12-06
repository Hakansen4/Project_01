using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat
{
    private float power;
    private float waitTime;
    private float explodeTime;
    private Rigidbody2D rb;

    public PlayerCombat(float power, float waitTime, Rigidbody2D rb)
    {
        this.power = power;
        this.waitTime = waitTime;
        this.rb = rb;
        explodeTime = 0;
    }
    public void Explode()
    {
        explodeTime = Time.time;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * power);
    }
    public bool CanExplode()
    {
        if (Time.time - explodeTime > waitTime)
            return true;

        return false;
    }
}

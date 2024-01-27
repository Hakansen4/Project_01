using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat
{
    private float power;
    private float waitTime;
    private float explodeTime;
    private Rigidbody2D rb;
    private Transform transform;

    private Vector2 GetHitDirection(Vector3 enemy, Vector3 player)
    {
        Vector2 direction = (enemy - player).normalized;

        if(direction == Vector2.zero)
            direction = Vector2.one;

        return direction;
    }

    public PlayerCombat(float power, float waitTime, Rigidbody2D rb, Transform transform)
    {
        this.power = power;
        this.waitTime = waitTime;
        this.rb = rb;
        this.transform = transform;
        explodeTime = 0;
    }
    public void Explode()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * power);
        explodeTime = Time.time;
    }
    public void PushEnemies(Collider2D[] enemies)
    {
        foreach(var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            enemy.GetComponent<IHittable>()?.Hit(power * 1 / distance, 
                                                GetHitDirection(enemy.transform.position, transform.position));
        }
    }
    public bool CanExplode()
    {
        if (Time.time - explodeTime > waitTime)
            return true;

        return false;
    }
}

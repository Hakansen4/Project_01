using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement
{
    private float speed;
    private Rigidbody2D rb;
    private float horizontalValue = 0f;

    private bool canMove = false;
    private bool isStuck = false;
    public ObjectMovement(float Speed, Rigidbody2D rb)
    {
        speed = Speed;
        this.rb = rb;
    }
    public void MoveWorks()
    {
        CheckStuck();
        if (!canMove)
            return;

        Move();
    }
    public float GetPushSpeed()
    {
        if (!isStuck)
            return speed;
        return 0.0f;
    }

    public void StartPush()
    {
        canMove = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void StopPush()
    {
        rb.bodyType = RigidbodyType2D.Static;
        canMove = false;
    }

    private void CheckStuck()
    {
        if (InputManager.GetHoriontalValue() != 0.0f && rb.velocity.x == 0)
            isStuck = true;
        else
            isStuck = false;
    }

    private void Move()
    {
        horizontalValue = InputManager.GetHoriontalValue();

        rb.velocity = new Vector2(horizontalValue * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}

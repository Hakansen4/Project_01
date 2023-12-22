using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement
{
    private float speed;
    private float chainSpeed;
    private Rigidbody2D rb;
    private float horizontalValue = 0f;

    private bool canMove = false;
    private bool isStuck = false;
    private bool isPushedChain = false;
    public ObjectMovement(float Speed, Rigidbody2D rb)
    {
        speed = Speed;
        this.rb = rb;
    }
    public void ChainPush(float Speed)
    {
        chainSpeed = Speed;
        isPushedChain = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void MoveWorks()
    {
        CheckChainPush();
        CheckStuck();
        if (!canMove)
            return;

        Move(speed);
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
        isPushedChain = false;
    }
    private void CheckChainPush()
    {
        if (isPushedChain)
            Move(chainSpeed);

    }
    private void CheckStuck()
    {
        if (InputManager.GetHoriontalValue() != 0.0f && rb.velocity.x == 0)
            isStuck = true;
        else
            isStuck = false;
    }

    private void Move(float Speed)
    {
        horizontalValue = InputManager.GetHoriontalValue();

        rb.velocity = new Vector2(horizontalValue * Speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}

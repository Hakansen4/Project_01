using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private float runningSpeed;
    private float jumpPower;
    private Rigidbody2D rigidbody;
    private Transform transform;
    private Vector3 destination;
    private float HorizontalValue;
    public PlayerMovement(float runningSpeed, Rigidbody2D rigidbody, Transform transform, float jumpPower)
    {
        this.runningSpeed = runningSpeed;
        this.rigidbody = rigidbody;
        this.transform = transform;
        this.jumpPower = jumpPower;
    }
    public void Run()
    {
        Move(runningSpeed);
    }
    public void Jump()
    {
        rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpPower));
    }

    private void Move(float speed)
    {
        HorizontalValue = InputManager.GetHoriontalValue();

        rigidbody.velocity = new Vector2(HorizontalValue * speed * Time.fixedDeltaTime, rigidbody.velocity.y);
        SetDirection(HorizontalValue);
    }

    private void SetDirection(float Value)
    {
        if (Value > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Value < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private float runningSpeed;
    private float jumpPower;
    private Rigidbody2D rigidbody;
    private Transform transform;
    private float horizontalValue;
    private float pushSpeed;
    public PlayerMovement(float runningSpeed, Rigidbody2D rigidbody, Transform transform, float jumpPower,float pushSpeed)
    {
        this.runningSpeed = runningSpeed;
        this.rigidbody = rigidbody;
        this.transform = transform;
        this.jumpPower = jumpPower;
        this.pushSpeed = pushSpeed;
    }
    public void Run()
    {
        Move(runningSpeed);
        SetDirection(horizontalValue);
    }
    public void Jump()
    {
        rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpPower));
    }
    public float PushMove()
    {
        Move(pushSpeed);
        return horizontalValue * transform.localScale.x;
    }

    private void Move(float speed)
    {
        horizontalValue = InputManager.GetHoriontalValue();

        rigidbody.velocity = new Vector2(horizontalValue * speed * Time.fixedDeltaTime, rigidbody.velocity.y);
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

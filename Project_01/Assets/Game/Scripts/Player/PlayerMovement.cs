using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private float runningSpeed;
    private float jumpPower;
    private float pushBackPower;
    private Rigidbody2D rigidbody;
    private Transform transform;
    private float horizontalValue;
    public PlayerMovement(float runningSpeed, Rigidbody2D rigidbody, Transform transform, float jumpPower, float pushBackPower)
    {
        this.runningSpeed = runningSpeed;
        this.rigidbody = rigidbody;
        this.transform = transform;
        this.jumpPower = jumpPower;
        this.pushBackPower = pushBackPower;
    }
    public void Run()
    {
        Move(runningSpeed);
        SetDirection(horizontalValue);
    }
    public void Jump()
    {
        rigidbody.velocity *= Vector2.right;
        rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpPower));
    }
    public float PushMove(float PushSpeed)
    {
        Move(PushSpeed);
        return horizontalValue * transform.localScale.x;
    }

    public void HittedMove(bool isHittedLeft)
    {
        if(!isHittedLeft)
        {
            rigidbody.AddForce(new Vector2(-1,0.7f) * pushBackPower, ForceMode2D.Impulse);
            SetDirection(1);
        }
        else
        {
            rigidbody.AddForce(new Vector2(1, 0.7f) * pushBackPower, ForceMode2D.Impulse);
            SetDirection(-1);
        }
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

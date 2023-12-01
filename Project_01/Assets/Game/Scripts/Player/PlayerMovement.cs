using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private float runningSpeed;
    private Rigidbody2D rigidbody;
    private Transform transform;
    private Vector3 destination;

    public PlayerMovement(float runningSpeed, Rigidbody2D rigidbody, Transform transform)
    {
        this.runningSpeed = runningSpeed;
        this.rigidbody = rigidbody;
        this.transform = transform;
    }
    public void Run()
    {
        Move(runningSpeed);
    }

    private void Move(float speed)
    {
        float HorizontalValue = InputManager.GetHoriontalValue();

        destination = new Vector3(transform.position.x + speed * HorizontalValue * Time.fixedDeltaTime,
                            transform.position.y, transform.position.z);

        rigidbody.MovePosition(destination);

        SetDirection(HorizontalValue);
    }

    private void SetDirection(float Value)
    {
        if (Value > 0)
        {
            Debug.Log("Turned right");
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Value < 0)
        {
            Debug.Log("Turned left");
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

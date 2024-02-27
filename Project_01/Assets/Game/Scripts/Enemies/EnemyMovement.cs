using System.Collections;
using UnityEngine;

public class EnemyMovement
{
    private EnemyChase chase;
    private EnemyPatrol patrol;

    private Transform transform;
    private Rigidbody2D rb;
    private float speed;
    public AIMoveDirection moveDirection;

    public EnemyMovement(Transform transform,Transform playerTransform,Rigidbody2D rb,float Speed, Vector3 leftBorder, Vector3 rightBorder)
    {
        moveDirection = AIMoveDirection.right;
        this.transform = transform;
        this.rb = rb;
        speed = Speed;

        chase = new EnemyChase(transform, playerTransform, this);
        patrol = new EnemyPatrol(this,transform,leftBorder,rightBorder);
    }
    public Vector2 CurrentVelocity()
    {
        return rb.velocity;
    }
    public void PatrolMove()
    {
        Move(moveDirection);
        patrol?.CheckPatroBorders();
    }
    public void ChaseMove()
    {
        chase?.CheckPlayerPosition();
        Move(moveDirection);
    }
    
    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
    public IEnumerator ChangeDirection(AIMoveDirection newDirection, float waitTime)
    {
        moveDirection = AIMoveDirection.stop;
        yield return new WaitForSeconds(waitTime);
        moveDirection = newDirection;
        transform.localScale = new Vector3(((float)newDirection), 1, 1);
    }
    private void Move(AIMoveDirection moveDirection)
    {
        rb.velocity = new Vector2(((float)moveDirection) * speed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
public enum AIMoveDirection
{
    left = -1,right = 1,stop = 0
}

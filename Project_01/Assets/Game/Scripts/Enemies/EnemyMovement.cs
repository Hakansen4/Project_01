using System.Collections;
using UnityEngine;

public class EnemyMovement
{
    private Transform transform;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private MonoBehaviour mono;
    private Vector3 leftBorder;
    private Vector3 rightBorder;
    private float speed;
    private AIMoveDirection moveDirection;

    public EnemyMovement(Transform transform,Transform playerTransform,Rigidbody2D rb,float Speed, Vector3 leftBorder, Vector3 rightBorder)
    {
        this.playerTransform = playerTransform;
        moveDirection = AIMoveDirection.right;
        this.transform = transform;
        this.mono = transform.GetComponent<MonoBehaviour>();
        this.rb = rb;
        this.leftBorder = leftBorder;
        this.rightBorder = rightBorder;
        this.speed = Speed;
    }
    public void PatrolMove()
    {
        Move(moveDirection);
        CheckPatroBorders();
    }
    public void ChaseMove()
    {
        CheckPlayerPosition();
        Move(moveDirection);
    }
    private void CheckPatroBorders()
    {
        if (transform.position.x <= leftBorder.x && moveDirection == AIMoveDirection.left)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.right , 2));
        }
        else if (transform.position.x >= rightBorder.x && moveDirection == AIMoveDirection.right)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.left , 2));
        }
    }
    private void CheckPlayerPosition()
    {
        if(transform.position.x <=  playerTransform.position.x && moveDirection == AIMoveDirection.left)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.right, 0));
        }
        else if(moveDirection == AIMoveDirection.right  &&  transform.position.x >= playerTransform.position.x)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.left, 0));
        }
    }
    private IEnumerator ChangeDirection(AIMoveDirection newDirection, float waitTime)
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
enum AIMoveDirection
{
    left = -1,right = 1,stop = 0
}

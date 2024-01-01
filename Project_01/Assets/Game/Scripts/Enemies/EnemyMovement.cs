using System.Collections;
using UnityEngine;

public class EnemyMovement
{
    private Transform transform;
    private Rigidbody2D rb;
    private MonoBehaviour mono;
    private Vector3 leftBorder;
    private Vector3 rightBorder;
    private float speed;
    private AIMoveDirection moveDirection;

    public EnemyMovement(Transform transform,Rigidbody2D rb,float Speed, Vector3 leftBorder, Vector3 rightBorder)
    {
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
    private void CheckPatroBorders()
    {
        if (transform.position.x <= leftBorder.x && moveDirection == AIMoveDirection.left)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.right));
        }
        else if (transform.position.x >= rightBorder.x && moveDirection == AIMoveDirection.right)
        {
            mono.StartCoroutine(ChangeDirection(AIMoveDirection.left));
        }
    }
    private IEnumerator ChangeDirection(AIMoveDirection newDirection)
    {
        moveDirection = AIMoveDirection.stop;
        yield return new WaitForSeconds(2);
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

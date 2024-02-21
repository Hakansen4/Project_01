using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPatrol
{
    private EnemyMovement movement;
    private Transform transform;
    private Vector3 leftBorder;
    private Vector3 rightBorder;
    private MonoBehaviour mono;

    public EnemyPatrol(EnemyMovement movement, Transform transform, Vector3 leftBorder, Vector3 rightBorder)
    {
        this.movement = movement;
        this.transform = transform;
        this.leftBorder = leftBorder;
        this.rightBorder = rightBorder;
        mono = transform.GetComponent<MonoBehaviour>();
    }

    public void CheckPatroBorders()
    {
        if (transform.position.x <= leftBorder.x && movement.moveDirection == AIMoveDirection.left)
        {
            mono.StartCoroutine(movement.ChangeDirection(AIMoveDirection.right, 0));
        }
        else if (transform.position.x >= rightBorder.x && movement.moveDirection == AIMoveDirection.right)
        {
            mono.StartCoroutine(movement.ChangeDirection(AIMoveDirection.left, 0));
        }
    }
}

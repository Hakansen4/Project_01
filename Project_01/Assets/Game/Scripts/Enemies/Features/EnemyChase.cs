using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyChase
{
    private readonly EnemyMovement movement;
    private readonly Transform transform;
    private readonly Transform playerTransform;
    private readonly MonoBehaviour mono;
    public EnemyChase(Transform transform, Transform playerTransform,EnemyMovement movement) 
    {
        this.movement = movement;
        this.transform = transform;
        this.playerTransform = playerTransform;
        mono = transform.GetComponent<MonoBehaviour>();
    }

    public void CheckPlayerPosition()
    {
        if (transform.position.x <= playerTransform.position.x && movement.moveDirection == AIMoveDirection.left)
        {
            ChangeMovementDirection(AIMoveDirection.right);
        }
        else if (movement.moveDirection == AIMoveDirection.right && transform.position.x >= playerTransform.position.x)
        {
            ChangeMovementDirection(AIMoveDirection.left);
        }
    }
    private void ChangeMovementDirection(AIMoveDirection direction)
    {
        mono.StartCoroutine(movement.ChangeDirection(direction, 0));
    }
}

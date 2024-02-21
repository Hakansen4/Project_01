using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyChase
{
    private EnemyMovement movement;
    private Transform transform;
    private Transform playerTransform;
    private MonoBehaviour mono;
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
            mono.StartCoroutine(movement.ChangeDirection(AIMoveDirection.right, 0));
        }
        else if (movement.moveDirection == AIMoveDirection.right && transform.position.x >= playerTransform.position.x)
        {
            mono.StartCoroutine(movement.ChangeDirection(AIMoveDirection.left, 0));
        }
    }
}

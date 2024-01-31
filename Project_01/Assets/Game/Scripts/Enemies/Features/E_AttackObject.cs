using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackObject : MonoBehaviour, IPoolable
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private float _speed;

    private ObjectPool<E_AttackObject> pool;
    private int direction = 1;
    public void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartDeactivateTimer());
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _rb.velocity = new Vector2(_speed * Time.fixedDeltaTime * direction, _rb.velocity.y);
    }
    private IEnumerator StartDeactivateTimer()
    {
        yield return new WaitForSeconds(_deactivateTime);
        pool.ObjectDeactivated(this);
        DeActivate();
    }
    public void SetCreater(ObjectPool<E_AttackObject> pool)
    {
        this.pool = pool;
    }
    public void SetDirection(int direction)
    {
        this.direction = direction;
        transform.localScale = new Vector3(direction, 1, 1);
    }

    
}

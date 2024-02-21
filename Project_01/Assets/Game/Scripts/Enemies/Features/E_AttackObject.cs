using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackObject : MonoBehaviour, IPoolable
{
    #region Components
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Rigidbody2D _rb;
    #endregion
    private float damage;
    private float deactivateTime;
    private float speed;

    private ObjectPool<E_AttackObject> pool;
    private int direction = 1;
    public void Activate()
    {
        gameObject.SetActive(true);
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
        _rb.velocity = new Vector2(speed * Time.fixedDeltaTime * direction, _rb.velocity.y);
    }
    private IEnumerator StartDeactivateTimer()
    {
        yield return new WaitForSeconds(deactivateTime);
        DestroyObject();
    }
    public void DestroyObject()
    {
        pool.ObjectDeactivated(this);
        DeActivate();
    }
    public void SetCreater(ObjectPool<E_AttackObject> pool)
    {
        this.pool = pool;
        StartCoroutine(StartDeactivateTimer());
    }
    public void SetupAttackObject(EnemyAttackObject data)
    {
        _renderer.sprite = data.Sprite;
        speed = data.Speed;
        deactivateTime = data.DeactivateTime;
        damage = data.Damage;
    }
    public void SetDirection(int direction)
    {
        this.direction = direction;
        transform.localScale = new Vector3(direction, 1, 1);
    }
    public float GetDamage()
    {
        return damage;
    }
}
public enum EnemyType
{
    Type_0
}
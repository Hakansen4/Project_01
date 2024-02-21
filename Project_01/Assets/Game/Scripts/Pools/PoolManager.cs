using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PoolManager : MonoBehaviour
{
    #region EnemyAttack
    [FoldoutGroup(GlobalStrings.Pool_EnemyAttack), SerializeField] private GameObject _attackObject;
    [FoldoutGroup(GlobalStrings.Pool_EnemyAttack), SerializeField] private int _sizeOfAttackObjectPool;

    private static ObjectPool<E_AttackObject> poolAttackObject;
    #endregion

    private void Awake()
    {
        InitializePools();
    }
    private void InitializePools()
    {
        poolAttackObject = new ObjectPool<E_AttackObject>(_sizeOfAttackObjectPool, _attackObject);
    }

    public static void SetEnemyAttackObject(Vector3 createPosition, int direction, EnemyAttackObject attackObject)
    {
        var obj = poolAttackObject.GetPooledObject();
        obj.SetupAttackObject(attackObject);
        obj.SetCreater(poolAttackObject);
        obj.SetDirection(direction);
        obj.transform.position = createPosition;
    }
}

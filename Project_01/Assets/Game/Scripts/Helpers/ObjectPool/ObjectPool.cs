using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable
{
    private T[] Pool;
    private GameObject Prefab;
    private int amountOfPool;
    private int index;
    public ObjectPool(int AmountOfPool, GameObject PooledObject)
    {
        amountOfPool = AmountOfPool;
        Prefab = PooledObject;
        Pool = new T[amountOfPool];
        index = -1;
        CreatePool(0, amountOfPool);
    }
    private void CreatePool(int firstIndex, int LastIndex)
    {
        T tmp;
        for (int i = firstIndex; i < LastIndex; i++)
        {
            tmp = GameObject.Instantiate(Prefab).GetComponent<T>();
            tmp.DeActivate();
            Pool[i] = tmp;
        }
    }
    public T GetPooledObject()
    {
        if (index < Pool.Length - 1)
        {
            index++;
            Pool[index].Activate();
            return Pool[index];
        }
        else
        {
            index++;
            return ExtendPool();
        }
    }

    private T ExtendPool()
    {
        ExtendArray();
        CreatePool(index, amountOfPool);
        Pool[index].Activate();
        return Pool[index];
    }
    private void ExtendArray()
    {
        T[] tmp = new T[amountOfPool * 2];
        for (int i = 0; i < amountOfPool; i++)
        {
            tmp[i] = Pool[i];
        }
        Pool = tmp;
        amountOfPool *= 2;
    }

    public void ObjectDeactivated(T obj)
    {
        index--;
        Pool[index + 1] = obj;
    }
}
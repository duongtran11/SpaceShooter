using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> where T : PoolObject
{
    private Queue<T> _pool;
    private T _prefab;
    public void Initialize(int initialSize, T prefab)
    {
        _pool = new Queue<T>();
        _prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            _pool.Enqueue(Create());
        }
    }
    private T Create()
    {
        T obj = Object.Instantiate(_prefab);
        obj.OnReturn += (o) => ReturnToPool((T)o);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public T GetFromPool(Vector3 position, Quaternion rotation)
    {
        T obj;
        if (_pool.Count > 0)
        {
            obj = _pool.Dequeue();
        }
        else
        {
            obj = Create();
        }
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}

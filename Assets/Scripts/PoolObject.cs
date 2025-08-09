using System;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public Action<PoolObject> OnReturn;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter + " + collision.name);
        OnReturn?.Invoke(this);
    }
}

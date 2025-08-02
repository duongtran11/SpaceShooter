using System;
using UnityEngine;

[Serializable]
public class EnemyWave : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public FlyPath FlyPath;
    public int EnemyNumber;
    public float FlySpeed = 1;
    public Vector3 OffsetPosition;
    public float NextWaveDelay;
}

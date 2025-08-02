using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] Waves;
    private int _currentWave;
    void Start()
    {
        SpawnWave();
    }
    void SpawnWave()
    {
        var wave = Waves[_currentWave];
        var startPos = wave.FlyPath[0];

        for (int i = 0; i < wave.EnemyNumber; i++)
        {
            var enemyGO = Instantiate(wave.EnemyPrefab, startPos, Quaternion.identity);
            var enemy = enemyGO.GetComponentInChildren<EnemyController>();
            enemy.FlyPath = wave.FlyPath;
            enemy.FlySpeed = wave.FlySpeed;
            startPos += wave.OffsetPosition;
        }
        _currentWave++;

    }
}

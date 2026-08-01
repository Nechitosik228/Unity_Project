using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private EnemyStats stats1;
    [SerializeField] private EnemyController enemyPrefab;

    [SerializeField] private List<Transform> spawnpoints;
    
    private void Start()
    {
        SpawnEnemy();
        SpawnEnemy1();
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnpoints.Count);
        Transform spawnPoint = spawnpoints[randomIndex];
        EnemyController enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.Initialize(stats);
    }

    private void SpawnEnemy1()
    {
        int randomIndex = Random.Range(0, spawnpoints.Count);
        Transform spawnPoint = spawnpoints[randomIndex];
        EnemyController enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.Initialize(stats1);
    }
}

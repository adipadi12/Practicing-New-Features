using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawnPoint;

    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float spawnRadius = 10f;

    [SerializeField] private int poolSize = 5;
    private float spawnTimer;

    private List<GameObject> enemyPool = new List<GameObject>();

    void Start()
    {
        CreatePool();
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GetPooledEnemy();
        if (enemy == null)
        {
            return;
        }

        Vector3 spawnPosition = transform.position;
        spawnPosition.x += UnityEngine.Random.Range(-spawnRadius, spawnRadius);
        spawnPosition.y = 0f;

        enemy.transform.position = spawnPosition;
        enemy.SetActive(true);
    }

    private GameObject GetPooledEnemy()
    {
        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    public void ResetSpawner()
    {
        foreach (var enemy in enemyPool)
        {
            enemy.SetActive(false);
        }
        spawnTimer = 0f;
    }
}

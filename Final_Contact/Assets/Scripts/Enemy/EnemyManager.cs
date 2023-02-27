using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] EnemyPrefabs;
    [SerializeField]
    private int enemyLimit;
    private int enemies;
    [SerializeField]
    private int enemyLevelCount;
    [SerializeField]
    private float spawnCooldown = 0.25f;
    private float lastSpawn;

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies < enemyLimit && enemyLevelCount > 0 && (Time.time >= (lastSpawn+spawnCooldown)))
        {
            SpawnNewEnemy();
            lastSpawn = Time.time;
        }
    }
    void SpawnNewEnemy()
    {
        int randomPrefab = Random.Range(0, EnemyPrefabs.Length);
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        Instantiate(EnemyPrefabs[randomPrefab], SpawnPoints[randomNumber].transform.position, Quaternion.identity);
        enemyLevelCount--;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] EnemyPrefabs;
    public GameObject nextLevelDoor;
    [SerializeField]
    private int baseEnemyCount = 20;
    private readonly int baseEnemyLimit = 20;
    [SerializeField]
    private int enemyLimit;
    private int enemies;
    public int enemyLevelCount;
    [SerializeField]
    private int enemySpawnCount;
    [SerializeField]
    private float spawnCooldown = 0.25f;
    private float lastSpawn;
    private bool firstSpawn;
        private void Start()
    {
        firstSpawn = true;
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            if (!firstSpawn)
            {
                Debug.Log("Spawning");
                SpawnUpdate();
            }
            else if (firstSpawn) 
            {
                enemyLevelCount = baseEnemyCount * GameObject.FindGameObjectsWithTag("Player").Length;
                enemyLimit = baseEnemyLimit * GameObject.FindGameObjectsWithTag("Player").Length;
                enemySpawnCount = enemyLevelCount;
                firstSpawn = false;
                Debug.Log(firstSpawn);
            }
        }
    }
    private void SpawnUpdate()
    {
        Debug.Log("InSpawnUpdate");
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies < enemyLimit && enemySpawnCount > 0 && (Time.time >= (lastSpawn + spawnCooldown)))
        {
            SpawnNewEnemy();
            lastSpawn = Time.time;
        }
        if (enemyLevelCount <= 0)
        {
            //Instantiate(nextLevelDoor,);
        }
    }
    void SpawnNewEnemy()
    {
        int randomPrefab = Random.Range(0, EnemyPrefabs.Length);
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        Instantiate(EnemyPrefabs[randomPrefab], SpawnPoints[randomNumber].transform.position, Quaternion.identity);
        enemySpawnCount--;
    }
}

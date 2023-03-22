using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] EnemyPrefabs;
    [SerializeField]
    private int baseEnemyCount = 20;
    [SerializeField]
    private readonly int baseEnemyLimit = 15;
    [SerializeField]
    private int enemyLimit;
    public int enemies;
    public int enemyLevelCount;
    [SerializeField]
    private int enemySpawnCount;
    [SerializeField]
    private float spawnCooldown = 0.25f;
    private float lastSpawn;
    public static bool firstSpawn;
    private void Start()
    {
        firstSpawn = true;
        
    }
    private void Update()
    {
        //Looks through the scene if there are any players, doesnt spawn any enemies unless players exist
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            //If the first enemy hasnt spawned yet it will skip to the else if statement
            if (!firstSpawn)
            {
                SpawnUpdate();
            }
            //If the first enemy hasnt spawned this else if statement will run
            else if (firstSpawn) 
            {
                enemyLevelCount = baseEnemyCount * GameObject.FindGameObjectsWithTag("Player").Length;
                enemyLimit = baseEnemyLimit * GameObject.FindGameObjectsWithTag("Player").Length;
                enemySpawnCount = enemyLevelCount;
                if(SceneManager.GetActiveScene().name == "LVL3Miniboss")
                {
                    enemyLevelCount++;
                }
                firstSpawn = false;
            }
        }
    }
    private void SpawnUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Spawns enemies until it reaches the currently spawned limit or runs out of enemis to spawn per level
        if (enemies < enemyLimit && enemySpawnCount > 0 && (Time.time >= (lastSpawn + spawnCooldown)))
        {
            SpawnNewEnemy();
            lastSpawn = Time.time;
        }
    }
    void SpawnNewEnemy()
    {
        float randomizer = Random.value;
        int enemySelectorTop = 0;
        int enemySelectorBottom = 0;
        if (randomizer > 0.3) // 70% chance
        {
            enemySelectorTop = 2; // +1 as random.range top is exclusive not inclusive
        }
        if (randomizer > 0.7) // 30% chance
        {
            enemySelectorBottom = 2;
            enemySelectorTop = 5; // +1 as random.range top is exclusive not inclusive
        }
        //Randomizes which enemy type will spawn
        int randomPrefab = Random.Range(enemySelectorBottom, enemySelectorTop); 
        //Randomizes which door the enemy will spawn at
        int randomNumber = Random.Range(0, SpawnPoints.Length - 1);
        //Spawns the enemy with random type and spawn door
        Instantiate(EnemyPrefabs[randomPrefab], SpawnPoints[randomNumber].transform.position, Quaternion.identity);
        //Decreases enemySpawnCount by one so the correct amount of enemies will spawn per level
        enemySpawnCount--;
    }
}

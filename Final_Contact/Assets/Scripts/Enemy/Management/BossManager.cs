using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] EnemyPrefabs;
    //[SerializeField]
    //private int baseTurretCount = 20;
    //private readonly int baseEnemyLimit = 15;
    //[SerializeField]
    //private int enemyLimit;
    public int turrets;
    //public int enemyLevelCount;
    //[SerializeField]
    //private int enemySpawnCount;
    //[SerializeField]
    //private float spawnCooldown = 0.25f;

    public enum BossStage
    {
        Turrets,
        Boss
    }
    public BossStage activeStage;
    private void Start()
    {
        //firstSpawn = true;
        activeStage = BossStage.Turrets;
    }
    private void Update()
    {
        //Looks through the scene if there are any players, doesnt spawn any enemies unless players exist
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            SpawnUpdate();
        }
    }
    private void SpawnUpdate()
    {
        turrets = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Spawns enemies until it reaches the currently spawned limit or runs out of enemis to spawn per level
        if (turrets == 0 && activeStage == BossStage.Turrets)
        {
            SpawnTurrets();
        }
        
        
    }
    void SpawnTurrets()
    {
        Debug.Log("Spawning");
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(EnemyPrefabs[0], SpawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}

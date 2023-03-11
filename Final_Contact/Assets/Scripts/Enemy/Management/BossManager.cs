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
    public bool bossAttacking = false;
    public bool turretsSpawned = false;

    //public enum BossStage
    //{
    //    Turrets,
    //    Boss
    //}
    //public BossStage activeStage;
    private void Start()
    {
        //firstSpawn = true;
        //activeStage = BossStage.Turrets;
        turretsSpawned = true;
    }
    private void Update()
    {
        if (GetComponentInChildren<EnemyStandard>().health == 75) 
        {
            GetComponentInChildren<EnemyStandard>().health -= 1;
            bossAttacking = false;
        }
        if (!bossAttacking && GameObject.FindGameObjectsWithTag("Turret").Length <=3 && turretsSpawned == false)
        {
            SpawnTurrets();
            turretsSpawned = true;
        }
        if (GameObject.FindGameObjectsWithTag("Turret").Length <= 0)
        {
            bossAttacking = true;
            turretsSpawned = false;
        }
     
        //Looks through the scene if there are any players, doesnt spawn any enemies unless players exist
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

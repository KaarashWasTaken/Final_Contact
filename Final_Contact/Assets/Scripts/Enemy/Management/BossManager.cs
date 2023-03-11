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
    public bool fightingTurrets = false;
    public bool turretRespawn = false;

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
        if (GetComponentInChildren<EnemyStandard>().health == 100 || 
            GetComponentInChildren<EnemyStandard>().health == 75 || GetComponentInChildren<EnemyStandard>().health == 50 || 
            GetComponentInChildren<EnemyStandard>().health == 25)
        {
            activeStage = BossStage.Turrets;
            GetComponentInChildren<EnemyStandard>().health -= 1;  
            //make invulnerable to more damage
        }

        if (!fightingTurrets &&
            GameObject.FindGameObjectsWithTag("Turret").Length <= 5 &&
            GetComponentInChildren<EnemyNavMeshFinalBoss>().bossAttacking == false &&
            GetComponentInChildren<EnemyNavMeshFinalBoss>().bossCurrentPosition.position.x == GetComponentInChildren<EnemyNavMeshFinalBoss>().bossStartPosition.position.x &&
            GetComponentInChildren<EnemyNavMeshFinalBoss>().bossCurrentPosition.position.z == GetComponentInChildren<EnemyNavMeshFinalBoss>().bossStartPosition.position.z)
        {
            turretRespawn = true;
            SpawnTurrets();
            activeStage = BossStage.Turrets;
            fightingTurrets = true;
        }
        if (GameObject.FindGameObjectsWithTag("Turret").Length <= 0 && !turretRespawn )
        {
            activeStage = BossStage.Boss;
        }

    }

    void SpawnTurrets()
    {
        Debug.Log("Spawning");
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(EnemyPrefabs[0], SpawnPoints[i].transform.position, Quaternion.identity);
        }
        turretRespawn = false;
    }
}
//activeStage == BossStage.Turrets && 
//GetComponentInChildren<EnemyNavMeshFinalBoss>().bossCurrentPosition == GetComponentInChildren<EnemyNavMeshFinalBoss>().bossStartPosition
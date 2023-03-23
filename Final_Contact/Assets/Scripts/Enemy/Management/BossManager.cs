using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] EnemyPrefabs;
    public int turrets;
    public bool bossAttacking = false;
    public bool turretsActive = false;
    private bool switchStage = true;
    public float bossHealth;
    private void Start()
    {
        turretsActive = true;
    }
    private void Update()
    {
        if (GetComponentInChildren<EnemyBossStandard>().health <= 0.75 * bossHealth && GetComponentInChildren<EnemyBossStandard>().health >= 0.50 * bossHealth && switchStage)
        {
            switchStage = false;
            bossAttacking = false;
        }
        if (GetComponentInChildren<EnemyBossStandard>().health <= 0.50 * bossHealth && GetComponentInChildren<EnemyBossStandard>().health >= 0.25 * bossHealth && !switchStage)
        {
            switchStage = true;
            bossAttacking = false;
        }
        if (GetComponentInChildren<EnemyBossStandard>().health <= 0.25 * bossHealth && GetComponentInChildren<EnemyBossStandard>().health >= 0 * bossHealth && switchStage)
        {
            switchStage = false;
            bossAttacking = false;
        }
        if (!bossAttacking && GameObject.FindGameObjectsWithTag("Turret").Length <=3 && turretsActive == false)
        {
            SpawnTurrets();
            turretsActive = true;
        }
        if (GameObject.FindGameObjectsWithTag("Turret").Length <= 0)
        {
            bossAttacking = true;
            turretsActive = false;
        }
        //Debug.Log(bossAttacking);
     
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

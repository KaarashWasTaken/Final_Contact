
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFinalBoss : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    //[SerializeField]
    //private float maxDistance = 60;
    [SerializeField]
    private float currentDistance;
    private bool dissolving;
    //Dash Damage
    [SerializeField]
    private float attackCD = 2.0f;
    private float lastAttack;

    [SerializeField]
    public Transform bossStartingPoint;
    [NonSerialized]
    public Transform bossCurrentPoint;
    public GameObject shield;
    [SerializeField]
    public static bool bossAtBase = false;
    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        bossCurrentPoint = GetComponent<Transform>();
        shield.SetActive(true);
    }
    private void Update()
    {
        bossCurrentPoint.position = transform.position;
       if(GetComponentInParent<BossManager>().bossAttacking == false) // boss stage turret
        {
            BossShielded();
        }
        if (GetComponentInParent<BossManager>().bossAttacking == true) // boss stage boss
        {
            BossAttack();
        }
    }

    public void BossAttack()
    {
        navMeshAgent.speed = 11;
        //Debug.Log(currentTarget);
        if (!dissolving)
        {
            //If the enemy doenst have a target or targets a downed player it will 
            if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
                currentTarget = GameObject.Find("TempTarget");

            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in players)
            {
                if (Vector3.Distance(g.transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position))
                {
                    currentTarget = g;
                }
            }
            if (currentTarget.CompareTag("Player"))
                navMeshAgent.destination = currentTarget.transform.position;

            if (GetComponent<EnemyBossStandard>().health <= 0)
            {
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }
    }
    public void BossShielded()
    {
        //Debug.Log("Shielded");
        navMeshAgent.speed = 18;
        navMeshAgent.destination = bossStartingPoint.position;
        //Debug.Log(bossStartingPoint.position);
    }
 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && (Time.time >= (lastAttack + attackCD)))
        {
            lastAttack = Time.time;
            other.gameObject.GetComponent<playerBehaviour>().health -= GetComponentInChildren<DamageMelee>().damage;
            navMeshAgent.isStopped = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossShieldPosition"))
        {
            bossAtBase = true;
            Debug.Log("boss at base");
            shield.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BossShieldPosition"))
        {
            bossAtBase = false;
            Debug.Log("bossaway");
            shield.SetActive(false);
        }
    }
}
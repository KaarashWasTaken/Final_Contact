
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
    [SerializeField]
    private float maxDistance = 60;
    [SerializeField]
    private float currentDistance;
    [SerializeField]
    private float timeUntilWander;
    private bool wandering = false;
    private bool dissolving;
    private bool dashing = false;
    //Dash Damage
    [SerializeField]
    private float attackCD = 2.0f;
    private float lastAttack;
    [SerializeField]
    private float dashDamage = 5f;

    [SerializeField]
    public Transform bossStartingPoint;
    [NonSerialized]
    public Transform bossCurrentPoint;
    public GameObject shield;
    public static bool bossAtBase = false;
    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        bossCurrentPoint = GetComponent<Transform>();
        //Invoke(nameof(Wander), Random.Range(3, 8));
        //InvokeRepeating(nameof(DashAtPlayer), 10, Random.Range(8, 16));
    }
    private void Update()
    {
        bossCurrentPoint.position = transform.position;
        if(bossCurrentPoint.position.x == bossStartingPoint.position.x && bossCurrentPoint.position.z == bossStartingPoint.position.z)
        {
            bossAtBase = true;
            Debug.Log("bossatbase");
        }
        else
        {
            bossAtBase = false;
            Debug.Log("boss away");
        }
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
        //Debug.Log("Attacking");
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

            if (GetComponent<EnemyStandard>().health <= 0)
            {
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }
    }
    public void BossShielded()
    {
        //Debug.Log("Shielded");
        navMeshAgent.destination = bossStartingPoint.position;
    }
 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && (Time.time >= (lastAttack + attackCD)))
        {
            lastAttack = Time.time;
            other.gameObject.GetComponent<playerBehaviour>().health -= dashDamage;
            navMeshAgent.isStopped = true;
        }
    }
}
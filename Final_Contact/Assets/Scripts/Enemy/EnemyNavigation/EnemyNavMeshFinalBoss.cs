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
    public Transform bossStartPosition;
    [NonSerialized]
    public Transform bossCurrentPosition;
    public GameObject shield;
    public bool bossAttacking = false;
    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        //Invoke(nameof(Wander), Random.Range(3, 8));
        InvokeRepeating(nameof(DashAtPlayer), 10, UnityEngine.Random.Range(8, 16));
        bossCurrentPosition = GetComponent<Transform>();
    }
    private void Update()
    {
        bossCurrentPosition.position = gameObject.transform.position;
        if (GetComponentInParent<BossManager>().activeStage == BossManager.BossStage.Turrets) // boss actions under turret stage
        {
            bossAttacking = false;
            navMeshAgent.destination = bossStartPosition.position;
            Debug.Log("BossShielded");
        }
        if (GetComponentInParent<BossManager>().activeStage == BossManager.BossStage.Boss) // boss action during attack stage
        {
            if (!dissolving && dashing)
            {

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
            Debug.Log("BossAttack");
        }

        //Debug.Log(bossCurrentPosition.position);
        //Debug.Log(bossStartPosition.position);

    }


    private void DashAtPlayer()
    {
        navMeshAgent.isStopped = false;
        dashing = true;
        navMeshAgent.speed *= 5;
        Invoke(nameof(EndDashAtPlayer), 1.0f);
    }

    private void EndDashAtPlayer()
    {
        navMeshAgent.isStopped = true;
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
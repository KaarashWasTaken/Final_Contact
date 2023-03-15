using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshMelee : MonoBehaviour
{
    private Rigidbody rb;
    public NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    private bool wandering = false;
    private bool dissolving;
    public bool isAttacking;
    private float lastAttack = -2;
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        rb= GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!dissolving)
        {
            //If the enemy doenst have a target or targets a downed player it will 
            if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
                currentTarget = GameObject.Find("TempTarget");
            if (currentTarget != gameObject.CompareTag("Player") && !wandering && !isAttacking)
            {
                Invoke(nameof(Wander), 0);
            }
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

    private void Wander()
    {
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position);
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), 1);
    }
    private void EndWander()
    {
        if (wandering)
            wandering = false;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            isAttacking = true;
            if (Time.time >= lastAttack + 2)
            {
                lastAttack = Time.time;
                Attack();
            }
        }
    }
    public void Attack()
    {
        Debug.Log("AttackCD");
        Invoke(nameof(StopCD), 1);
    }
    private void StopCD()
    {
        isAttacking = false;
        Debug.Log("AttackCdstopped");
    }
    private void Chase()
    {
        Debug.Log("Chasing");
        navMeshAgent.isStopped= false;
    }
}

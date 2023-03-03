using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshMelee : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    private bool wandering = false;

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
        rb.velocity = Vector3.zero;
        //If the enemy doenst have a target or targets a downed player it will 
        if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
            currentTarget = GameObject.Find("TempTarget");
        if (currentTarget != gameObject.CompareTag("Player") && !wandering)
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
}

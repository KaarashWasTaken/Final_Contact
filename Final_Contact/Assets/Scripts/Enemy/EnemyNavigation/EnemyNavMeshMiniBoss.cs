using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMiniBoss : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    [SerializeField]
    private float maxDistance = 50;
    [SerializeField]
    private float currentDistance;
    [SerializeField]
    private float timeUntilWander;
    private bool wandering = false;
    private bool dissolving;
    private bool dashing = false;
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        Invoke(nameof(Wander), Random.Range(3, 8));
    }
    private void Update()
    {
        InvokeRepeating(nameof(DashAtPlayer), 5.0f, 10.0f);

        // NavMeshRanged Scripting (main script)
        if (!dissolving && !dashing)
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
            currentDistance = Vector3.Distance(currentTarget.transform.position, gameObject.transform.position);
            if (currentDistance > maxDistance && !wandering)
            {
                navMeshAgent.SetDestination(currentTarget.transform.position);
                navMeshAgent.isStopped = false;
            }
            else if (currentDistance <= maxDistance && !wandering)
            {
                ShootAtPlayer();
            }
            if (GetComponent<EnemyStandard>().health <= 0)
            {
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }

        // NavMeshMelee Scripting
        if (!dissolving && dashing)
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
    private void ShootAtPlayer()
    {
        transform.LookAt(currentTarget.transform.position);
        navMeshAgent.isStopped = true;
        gameObject.GetComponentInChildren<EnemyShootShotgun>().Shoot();
    }
    private void Wander()
    {
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position);
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), Random.Range(1, 2));
    }
    private void EndWander()
    {
        transform.LookAt(currentTarget.transform.position);
        if (wandering)
            wandering = false;
        Invoke(nameof(Wander), Random.Range(6, 12));
    }
    private void DashAtPlayer()
    {
        dashing = true;
        navMeshAgent.speed *= 3;
        Invoke(nameof(EndDashAtPlayer), 0.2f);
    }

    private void EndDashAtPlayer()
    {
        dashing = false;
        navMeshAgent.speed = 10;
    }
}

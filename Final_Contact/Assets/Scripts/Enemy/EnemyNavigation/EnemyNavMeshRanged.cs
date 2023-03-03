using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshRanged : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    [SerializeField]
    private float maxDistance = 30;
    [SerializeField]
    private float currentDistance;
    [SerializeField]
    private float timeUntilWander;
    private bool wandering = false;
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponent<NavMeshAgent>();
        Invoke(nameof(Wander), Random.Range(3, 8));
    }
    private void Update()
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
        if(currentDistance > maxDistance && !wandering)
        {
            navMeshAgent.SetDestination(currentTarget.transform.position);
            navMeshAgent.isStopped = false;
        }
        else if(currentDistance <= maxDistance && !wandering)
        {
            ShootAtPlayer();
        }
        if (GetComponent<EnemyStandard>().health <= 0)
        {
            navMeshAgent.isStopped = true;
        }
    }
    private void ShootAtPlayer()
    {
        transform.LookAt(currentTarget.transform.position);
        navMeshAgent.isStopped = true;
        gameObject.GetComponent<EnemyShoot>().Shoot();
    }
    private void Wander()
    {
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position);
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), Random.Range(1, 3));
    }
    private void EndWander()
    {
        transform.LookAt(currentTarget.transform.position);
        if(wandering)
            wandering = false;
        Invoke(nameof(Wander), Random.Range(3, 8));
    }
}

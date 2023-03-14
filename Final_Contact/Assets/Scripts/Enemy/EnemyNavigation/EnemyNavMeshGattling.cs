using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshGattling : MonoBehaviour
{
    
    public NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    [SerializeField]
    private float maxDistance = 30;
    [SerializeField]
    private float currentDistance;
    [SerializeField]
    private float timeUntilWander;
    private bool wandering = false;
    private bool dissolving;
    public bool isShooting = false;
    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponent<NavMeshAgent>();
        Invoke(nameof(Wander), Random.Range(5, 10));
    }
    private void Update()
    {
        if (!dissolving)
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
    }
    private void ShootAtPlayer()
    {
        isShooting= true;
        transform.LookAt(currentTarget.transform.position);
        navMeshAgent.isStopped = true;
        gameObject.GetComponent<EnemyShoot>().SpreadShoot();
    }
    private void Wander()
    {
        isShooting = false;
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position);
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), Random.Range(1, 3));
    }
    private void EndWander()
    {
        transform.LookAt(currentTarget.transform.position);
        if (wandering)
            wandering = false;
        Invoke(nameof(Wander), Random.Range(5, 10));
    }
}

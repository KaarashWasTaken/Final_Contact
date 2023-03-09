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
    private float maxDistance = 30;
    [SerializeField]
    private float currentDistance;
    [SerializeField]
    private bool dissolving;
    public GameObject shield;

    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponent<NavMeshAgent>();
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
            if (currentDistance > maxDistance)
            {
                navMeshAgent.SetDestination(currentTarget.transform.position);
                navMeshAgent.isStopped = false;
            }
            else if (currentDistance <= maxDistance)
            {
                ShootAtPlayer();
            }

            if (GetComponent<EnemyStandard>().health <= 0)
            {

                shield.SetActive(true);
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }
    }
    private void ShootAtPlayer()
    {
        transform.LookAt(currentTarget.transform.position);
        navMeshAgent.isStopped = true;
        gameObject.GetComponent<EnemyShoot>().SpreadShoot();
    }
}

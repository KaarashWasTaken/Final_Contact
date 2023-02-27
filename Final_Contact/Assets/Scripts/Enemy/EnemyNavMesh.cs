using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;

    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
    }
    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(currentTarget== null)
            currentTarget = GameObject.Find("TempTarget");
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
        {
            if (Vector3.Distance(g.transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position))
            {
                currentTarget = g;
            }
        }
        navMeshAgent.destination = currentTarget.transform.position;
    }
}

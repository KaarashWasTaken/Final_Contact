using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshRanged : MonoBehaviour
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
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponent<NavMeshAgent>();
        Invoke(nameof(Wander), Random.Range(3, 8)); //The grunt starts wandering somewhere between 3-8 seconds after start
    }
    private void Update()
    {
        if (!dissolving)
        {
            if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
                currentTarget = GameObject.Find("TempTarget");
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in players)
            { //Sets current target to the closest player
                if (Vector3.Distance(g.transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position))
                {
                    currentTarget = g;
                }
            }
            currentDistance = Vector3.Distance(currentTarget.transform.position, gameObject.transform.position);
            if (currentDistance > maxDistance && !wandering) //Moves towards the player if the grunt is not close enough
            {
                navMeshAgent.SetDestination(currentTarget.transform.position);
                navMeshAgent.isStopped = false;
            }
            else if (currentDistance <= maxDistance && !wandering) //If the grunt is close enough and not wandering it will shoot at the player
            {
                isShooting = true;
                ShootAtPlayer();
            }
            if (GetComponent<EnemyStandard>().health <= 0) // Makes the grunt stop all it's doing if it's Hp is 0
            {
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }
    }
    private void ShootAtPlayer()
    { //Looks in the players direction, stops moving and starts shooting
        transform.LookAt(currentTarget.transform.position);
        navMeshAgent.isStopped = true;
        gameObject.GetComponent<EnemyShoot>().Shoot();
    }
    private void Wander()
    { //Set the navmesh destination to a random point around the grunt
        isShooting = false;
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position);
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), Random.Range(1, 3)); //Stops wandering after 1-3 seconds
    }
    private void EndWander()
    {
        transform.LookAt(currentTarget.transform.position);
        if(wandering)
            wandering = false;
        Invoke(nameof(Wander), Random.Range(3, 8)); //Starts wandering again after 3-8 seconds
    }
}

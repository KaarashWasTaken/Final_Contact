using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshBomber : MonoBehaviour
{
    [SerializeField]
    private float bomberDamage = 60;
    [SerializeField]
    private float explosionRadius = 5;
    [SerializeField]
    private float timeToExplosion = 0.5f;
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    private bool wandering = false;
    private bool isExploding = false;

    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        //If the enemy doenst have a target or targets a downed player it will 
        if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
            currentTarget = GameObject.Find("TempTarget");
        if (currentTarget != gameObject.CompareTag("Player") && !wandering && !isExploding)
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
        if (currentTarget.CompareTag("Player") && !isExploding)
            navMeshAgent.destination = currentTarget.transform.position;
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 0.5f); //check for players and trigger explosion
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                isExploding = true;
                navMeshAgent.isStopped = true;
                Invoke(nameof(BomberExplode), timeToExplosion);
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



    private void BomberExplode()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //check for players and do dmg
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                Debug.Log("ExplosionsDamage");
                c.GetComponent<playerBehaviour>().health -= bomberDamage;
                Destroy(transform.parent.gameObject);
            }
        }
        Destroy(transform.parent.gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshBomber : MonoBehaviour
{
    [SerializeField]
    private float bomberDamage = 80;
    [SerializeField]
    private float explosionRadius = 5;
    [SerializeField]
    private float timeToExplosion = 0.5f;
    private Rigidbody rb;
    public NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    private bool wandering = false;
    public bool isExploding = false;
    private bool dissolving;
    public ParticleSystem explosion;
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
        if (!dissolving)
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
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 1f); //check for players and trigger explosion
            foreach (Collider c in colliders)
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    if (!isExploding)
                    {
                        explosion.Play();
                        Invoke(nameof(BomberExplode), timeToExplosion);
                    }
                    isExploding = true;
                    navMeshAgent.isStopped = true;
                }
            }
            if (GetComponentInChildren<EnemyStandard>().health <= 0)
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
    private void BomberExplode()
    {
        GameObject.Find("ge_bomberCloud01").GetComponent<ExplosionDissolve>().exploding = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //check for players and do dmg
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                c.GetComponent<playerBehaviour>().health -= bomberDamage;
                GetComponentInChildren<EnemyStandard>().Death();
            }
            else
                Destroy(gameObject, 0.55f);
            //GetComponentInChildren<EnemyStandard>().Death();
        }
    }
}
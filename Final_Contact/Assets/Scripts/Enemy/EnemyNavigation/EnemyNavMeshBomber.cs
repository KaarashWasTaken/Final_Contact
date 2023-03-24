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
        if (!dissolving) // code will only run if bomber is alive
        {
            if (currentTarget == null || currentTarget.CompareTag("PlayerDown")) // sets target to a temporary target if it is targeting a downed player or doesnt have a target
                currentTarget = GameObject.Find("TempTarget");
            if (currentTarget != gameObject.CompareTag("Player") && !wandering && !isExploding) //if current target is not a player invoke wander function immediately
            {
                Invoke(nameof(Wander), 0);
            }
            players = GameObject.FindGameObjectsWithTag("Player"); // fill players array with all gameobjects tagged player
            foreach (GameObject g in players)
            {
                if (Vector3.Distance(g.transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position)) // checks for closest player and sets it as the current target
                {
                    currentTarget = g;
                }
            }
            if (currentTarget.CompareTag("Player") && !isExploding) // when it has a player targeted and isnt exploding it moves towards the targeted player
                navMeshAgent.destination = currentTarget.transform.position;
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 1f); //checks for players within overlap sphere originating on the bomber and trigger explosion
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //check for players and does dmg to them if they are within the sphere as well as setting bombers health to 0
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                c.GetComponent<playerBehaviour>().health -= bomberDamage;
                GetComponentInChildren<EnemyStandard>().health = 0;
            }
            GetComponentInChildren<EnemyStandard>().health = 0;
            GetComponentInChildren<EnemyStandard>().dissolveSpeed = 0.2f;
        }
    }
}
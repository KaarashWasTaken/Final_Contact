using UnityEngine;
using UnityEngine.AI;
public class EnemyNavMeshMelee : MonoBehaviour
{
    private Rigidbody rb;
    public NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    private bool wandering = false;
    private bool dissolving;
    public bool isAttacking;
    private float lastAttack = -2;
    private float timeNow;
    private bool chasing;
    public ParticleSystem slashEffect;
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
        timeNow = Time.time;
        if (!dissolving)
        {
            //If the enemy doenst have a target or targets a downed player it will 
            if (currentTarget == null || currentTarget.CompareTag("PlayerDown"))
                currentTarget = GameObject.Find("TempTarget");
            if (!currentTarget.CompareTag("Player") && !wandering && !isAttacking) //If no enemy detected the grunt starts wandering
            {
                Invoke(nameof(Wander), 0);
            }
            if (!wandering && !isAttacking && !chasing) //Start chasing if the grunt is not attacking or wandering
            {
                chasing = true;
                navMeshAgent.isStopped = false;
            }
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in players)
            { //checks for the closest player and sets it as the target
                if (Vector3.Distance(g.transform.position, gameObject.transform.position) < Vector3.Distance(currentTarget.transform.position, gameObject.transform.position)) 
                {
                    currentTarget = g;
                }
            }
            if (currentTarget.CompareTag("Player"))
                navMeshAgent.destination = currentTarget.transform.position;

            if (GetComponent<EnemyStandard>().health <= 0) //Stops the movement if the enemy has 0 HP
            {
                dissolving = true;
                navMeshAgent.isStopped = true;
            }
        }
    }
    private void Wander()
    { //Sets a wander destination in a random direction around the navmesh agent
        navMeshAgent.SetDestination(Random.onUnitSphere * 10 + gameObject.transform.position); 
        if (!wandering)
            wandering = true;
        navMeshAgent.isStopped = false;
        Invoke(nameof(EndWander), 1); //Stops wandering after 1 second
    }
    private void EndWander()
    {
        if (wandering)
            wandering = false;
    }
    private void OnTriggerStay(Collider collision)
    { //Keeps checking if a player is close enough for the grunt to slash it
        if (collision.gameObject.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true; // makes the grunt stop moving
            if (timeNow >= lastAttack + 2) //attack cooldown
            {
                chasing = false;
                isAttacking = true;
                slashEffect.Play(); //play a slash VFX
                lastAttack = Time.time;
                Invoke(nameof(StopCD), 1); //Stops the attack after 2 seconds
            }
        }
    }
    private void StopCD()
    {
        slashEffect.Stop(); //stop playing slash VFX
        isAttacking = false;
    }
}
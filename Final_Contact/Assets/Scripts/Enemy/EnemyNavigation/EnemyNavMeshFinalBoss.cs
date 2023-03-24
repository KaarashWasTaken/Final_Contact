
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFinalBoss : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private GameObject currentTarget;
    public bool bossReaction = false;
    public bool bossReacted = false;
    [SerializeField]
    private float currentDistance;
    private bool dying;
    //Dash Damage
    private float lastAttack;
    private float timeNow;
    public bool isAttacking = false;
    [SerializeField]
    private bool chasing = false;
    public Transform bossStartingPoint;
    [NonSerialized]
    public Transform bossCurrentPoint;
    public GameObject shield;
    public static bool bossAtBase = false;
    public Transform bossLookPos;
    // Start is called before the first frame update
    private void Start()
    {
        currentTarget = GameObject.Find("TempTarget");
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        bossCurrentPoint = GetComponent<Transform>();
        shield.SetActive(true);
    }
    private void Update()
    {
        timeNow = Time.time;
        bossCurrentPoint.position = transform.position;
       if(GetComponentInParent<BossManager>().bossAttacking == false) // boss stage turret
        {
            bossReacted = false;
            if(navMeshAgent.isStopped)
                navMeshAgent.isStopped = false;
            BossShielded();
            chasing= false;
            if (bossAtBase)
            {
                transform.LookAt(bossLookPos);
                Debug.Log("Setting boss look at");
            }
        }
        if (GetComponentInParent<BossManager>().bossAttacking == true) // boss stage boss
        {
            BossAttack();
            if(!bossReacted)
                bossReaction= true;
            Invoke(nameof(EndReaction), 4f);
            if (bossReaction)
            {
                Debug.Log("agent stopped");
                chasing = false;
                navMeshAgent.isStopped = true;
            }
        }
    }

    public void BossAttack()
    {
        navMeshAgent.speed = 18;
        //Debug.Log(currentTarget);
        if (!dying && !bossReaction)
        {
            if (!isAttacking && !chasing)
            {
                chasing = true;
                Debug.Log("agent chasing");
                navMeshAgent.isStopped = false;
            }
            //If the enemy doesnt have a target or targets a downed player it will find a new target
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

            if (GetComponent<EnemyBossStandard>().health <= 0)
            {
                dying = true;
                Debug.Log("agent stopped death");
                navMeshAgent.isStopped = true;
            }
        }
    }
    private void EndReaction()
    {
        bossReacted = true;
        bossReaction= false;
    }
    public void BossShielded()
    {
        bossReaction = false;
        navMeshAgent.speed = 24;
        navMeshAgent.destination = bossStartingPoint.position;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            if (timeNow >= lastAttack + 2)
            {
                chasing = false;
                isAttacking = true;
                lastAttack = Time.time;
                Invoke(nameof(StopCD), 2);
            }
        }
    }
    private void StopCD()
    {
        isAttacking = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossShieldPosition"))
        {
            bossAtBase = true;
            shield.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BossShieldPosition"))
        {
            bossAtBase = false;
            shield.SetActive(false);
        }
    }
}
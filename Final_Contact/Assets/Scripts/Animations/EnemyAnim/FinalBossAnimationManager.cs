using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAnimationManager : MonoBehaviour
{
    Animator animator;
    BossManager bossManager;
    EnemyNavMeshFinalBoss finalBoss;
    EnemyBossStandard bossStandard;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bossManager= GetComponentInParent<BossManager>();
        finalBoss = GetComponent<EnemyNavMeshFinalBoss>();
        bossStandard = GetComponent<EnemyBossStandard>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyNavMeshFinalBoss.bossAtBase && bossManager.turretsActive)
        {
            animator.SetBool("isSitting", true);
        }
        if(finalBoss.bossReacted)
        {
            animator.SetBool("isSitting", false);
        }
        if(finalBoss.bossReaction)
        {
            animator.SetBool("isReacting", true);
        }
        else
            animator.SetBool("isReacting", false);

        if (finalBoss.isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else
            animator.SetBool("isAttacking", false);
        if(bossStandard.health <= 0)
        {
            animator.SetBool("isDead", true);
        }
        if (!finalBoss.navMeshAgent.isStopped)
        {
            animator.SetBool("isWalking", true);
        }
        else
            animator.SetBool("isWalking", false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAnimationManager : MonoBehaviour
{
    EnemyNavMeshBomber bomber;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        bomber = GetComponentInParent<EnemyNavMeshBomber>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bomber.isExploding)
            animator.SetBool("isExploding", true);
        else
            animator.SetBool("isExploding", false);
        if (!bomber.navMeshAgent.isStopped)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);
    }
}

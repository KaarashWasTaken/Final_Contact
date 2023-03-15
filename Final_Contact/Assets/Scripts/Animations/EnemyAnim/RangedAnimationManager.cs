using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAnimationManager : MonoBehaviour
{
    EnemyNavMeshRanged ranged;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ranged = GetComponentInParent<EnemyNavMeshRanged>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ranged.isShooting)
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnimationManager : MonoBehaviour
{
    EnemyNavMeshMelee melee;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        melee = GetComponentInParent<EnemyNavMeshMelee>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (melee.isAttacking)
            animator.SetBool("isAttacking", true);
        else
            animator.SetBool("isAttacking", false);
    }
}

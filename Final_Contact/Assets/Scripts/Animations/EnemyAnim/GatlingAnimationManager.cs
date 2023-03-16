using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingAnimationManager : MonoBehaviour
{
    EnemyNavMeshGattling ranged;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ranged = GetComponentInParent<EnemyNavMeshGattling>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ranged.isShooting)
            animator.SetBool("isShooting", true);
        else
            animator.SetBool("isShooting", false);
    }
}

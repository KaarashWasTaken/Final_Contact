using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    PlayerController controller;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<PlayerController>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.shooting != 0)
            animator.SetBool("isShooting",true);
        else
            animator.SetBool("isShooting",false);
        if (controller.moving)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);
        if (controller.downed)
            animator.SetBool("isDowned", true);
        else
            animator.SetBool("isDowned", false);
    }
}

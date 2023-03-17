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
        animator.SetLayerWeight(2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.shooting != 0)
            animator.SetLayerWeight(animator.GetLayerIndex("Shooting"), 1);
        else
            animator.SetLayerWeight(animator.GetLayerIndex("Shooting"), 0);
        if (controller.moving)
            animator.SetFloat("Velocity", 1);
        else
            animator.SetFloat("Velocity", 0);
        if (controller.downed)
            animator.SetBool("isDowned", true);
        else
            animator.SetBool("isDowned", false);
    }
}

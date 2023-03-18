using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    PlayerController controller;
    Animator animator;
    WeaponManager weaponManager;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<PlayerController>();
        animator= GetComponent<Animator>();
        animator.SetLayerWeight(2, 0);
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.shooting != 0 || controller.aiming != Vector2.zero)
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Shooting"), 1);
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("Shooting"), 0);
            animator.SetBool("isShooting", false);
        }
        if (controller.moving)
            animator.SetFloat("Velocity", 1);
        else
            animator.SetFloat("Velocity", 0);
        if (controller.downed)
            animator.SetBool("isDowned", true);
        else
            animator.SetBool("isDowned", false);
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.AR)
        {
            animator.SetBool("AR", true);
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.Shotgun)
        {
            animator.SetBool("Shotgun", true);
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.MG)
        {
            animator.SetBool("MG", true);
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.SMG)
        {
            animator.SetBool("SMG", true);
        }
    }
}

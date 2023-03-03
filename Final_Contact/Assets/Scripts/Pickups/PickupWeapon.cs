using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.gameObject.GetComponentInChildren<WeaponManager>().playerWeapon==WeaponManager.EquippedWeapon.None)
                Destroy(gameObject);
        }
        
    }
}
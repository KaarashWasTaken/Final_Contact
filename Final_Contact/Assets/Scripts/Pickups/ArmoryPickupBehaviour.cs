using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryPickupBehaviour : MonoBehaviour
{
    public float health = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroys the pickup
            KillPickup();
        }
        if (other.CompareTag("Projectile"))
        {
            //Destroys the projectile
            Destroy(other.transform.parent.gameObject);
            //If the pickup has health

            if (health > 0)
            {
                //Decreases health by the damage variable in the projectile
                health -= other.GetComponentInParent<MoveForward>().damage;
            }
            //If the pickup has no health
            else
            {
                //Destroys the pickup
                KillPickup();
            }
        }
    }
    private void KillPickup()
    {
        Destroy(transform.parent.gameObject);
    }
}

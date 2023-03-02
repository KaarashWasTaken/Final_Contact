using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public float health = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
=======
            //Destroys the pickup
            Destroy(transform.parent.gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            //Destroys the projectile
            Destroy(other.transform.parent.gameObject);
            //If the pickup has health
>>>>>>> Stashed changes
            if (health > 0)
            {
                //Decreases health by the damage variable in the projectile
                health -= other.GetComponentInParent<MoveForward>().damage;
            }
            //If the pickup has no health
            else
            {
<<<<<<< Updated upstream
                Destroy(other.gameObject);
=======
                //Destroys the pickup
                Destroy(transform.parent.gameObject);
>>>>>>> Stashed changes
            }
        }
    }
}

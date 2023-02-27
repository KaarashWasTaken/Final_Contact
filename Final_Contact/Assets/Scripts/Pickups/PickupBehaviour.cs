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
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            if (health > 0)
            {
                health -= other.GetComponentInParent<MoveForward>().damage;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

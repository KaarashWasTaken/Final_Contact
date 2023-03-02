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
            Destroy(transform.parent.gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            if (health > 0)
            {
                health -= other.GetComponentInParent<MoveForward>().damage;
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}

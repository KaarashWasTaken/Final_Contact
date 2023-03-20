using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMelee : MonoBehaviour
{
    [SerializeField]
    private float attackCD = 0.5f;
    private float lastAttack;
    [SerializeField]
    public float damage = 30f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (Time.time >= (lastAttack + attackCD)))
        {
            lastAttack = Time.time;
            other.GetComponent<playerBehaviour>().health -= damage;
            Debug.Log("hit");
        }
    }
}

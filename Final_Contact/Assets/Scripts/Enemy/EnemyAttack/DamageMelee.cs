using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMelee : MonoBehaviour
{
    [SerializeField]
    private float damage = 30f;
    private float attackCD = 0.5f;
    private float lastAttack = -2;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= lastAttack + attackCD)
        {
            lastAttack= Time.time;
            other.GetComponent<playerBehaviour>().health -= damage;
            Debug.Log("hit");
        }
    }
}

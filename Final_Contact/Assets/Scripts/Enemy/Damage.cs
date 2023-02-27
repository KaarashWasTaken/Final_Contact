using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private float attackCD = 2.0f;
    private float lastAttack;
    [SerializeField]
    private float damage = 5f;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && (Time.time >= (lastAttack + attackCD)))
        {
            lastAttack = Time.time;
            other.gameObject.GetComponent<playerBehaviour>().health -= damage;
            Debug.Log("hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossStandard : MonoBehaviour
{
    private GameObject[] players;
    public float health = 1000; // boss health vs 1 player
    public ParticleSystem deathSpark;
    public static bool isDead = false;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player"); // boss health increased by 150hp per extra player 
        foreach (GameObject g in players)
        {
            health += 1000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Death();
        }
        
    }
    public void Death()
    {
        isDead= true;
        //Implement escape notification below
        Debug.Log("Get to the cockpit and escape!");
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile") && GetComponentInParent<BossManager>().bossAttacking)
        {
            health -= other.gameObject.GetComponent<MoveForward>().damage;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossStandard : MonoBehaviour
{
    private GameObject[] players;
    public float health = 1000; // boss health vs 1 player
    public ParticleSystem deathSpark;
    public static bool isDead = false;
    public static float maxHealth;
    public GameObject CockPitPopup;
    public Image BossHealth1;
    public Image BossHealth2;
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player"); // boss health increased by 150hp per extra player 
        for(int i = 0; i <= players.Length; i++)
        {
            health += 4000;
        }
        maxHealth= health;
        GetComponentInParent<BossManager>().bossHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        BossHealth1.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        BossHealth2.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            Death();
        }
        
    }
    public void Death()
    {
        isDead= true;
        //Implement escape notification below
        CockPitPopup.SetActive(true);
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().enemySpawnCount = 0;
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

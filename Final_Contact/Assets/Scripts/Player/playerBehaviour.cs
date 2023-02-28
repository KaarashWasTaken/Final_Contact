using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBehaviour : MonoBehaviour
{
    public float health;
    [SerializeField]
    private float maxHealth;
    public Image healthBar;
    //public bool downed;
    public float timeFiringSpeed;
    public float originalFiringSpeed;
    public bool firingSpeedActive = false;
    [SerializeField]
    private GameObject PlayerDownPrefab;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        originalFiringSpeed = gameObject.GetComponent<PlayerController>().firingspeed;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            GetComponent<PlayerController>().Down();
        }
        if (firingSpeedActive && gameObject.GetComponent<PlayerController>().firingspeed != originalFiringSpeed && Time.time > timeFiringSpeed)
        {
            gameObject.GetComponent<PlayerController>().firingspeed = originalFiringSpeed;
            firingSpeedActive = false;
        }
    }

    public void SetTrigger()
    {

    }

    //public void Down()
    //{
    //    downed = true;
    //    Destroy(transform.parent.gameObject);
       
    //    GameObject prefabToSpawn = Instantiate(PlayerDownPrefab,transform.position,transform.rotation);

    //}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            health -= other.gameObject.GetComponent<EnemyMoveForward>().damage;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupHealth"))
        {
            health += other.gameObject.GetComponent<PickupHealth>().healthBonus;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        if (other.gameObject.CompareTag("PickupFiringSpeed") && !firingSpeedActive)
        {
            firingSpeedActive = true;
            gameObject.GetComponent<PlayerController>().firingspeed += other.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedBonus;
            timeFiringSpeed = Time.time + other.gameObject.GetComponent<PickupFiringSpeed>().bonusTime;
        }
    }
    //public void Revived()
    //{

    //}
}

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
    public Image cooldownBar;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the maxHealth to health we should reverse it
        maxHealth = health;
        //originalFiringSpeed = gameObject.GetComponent<PlayerController>().firingspeed;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            GetComponent<PlayerController>().Down();
        }
        //cooldownBar.fillAmount = Mathf.Clamp(1 - GetComponentInChildren<WeaponManager>().heat, 0, 1);
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
        //If the player collides with a health pickup
        if (other.CompareTag("PickupHealth"))
        {
            health += other.gameObject.GetComponent<PickupHealth>().healthBonus;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        //If the player collides with a firerate pickup
        if (other.CompareTag("PickupFiringSpeed"))
        {
            gameObject.GetComponentInChildren<WeaponManager>().FiringSpeedBonus(other.gameObject);
        }
        //If the player has no weapon equipped
        if (gameObject.GetComponentInChildren<WeaponManager>().playerWeapon == WeaponManager.equippedWeapon.None)
        {
            //Makes the player pickup the weapon it collided with
            gameObject.GetComponentInChildren<WeaponManager>().PickupWeapon(other.gameObject);
        }
    }
    //public void Revived()
    //{

    //}
}

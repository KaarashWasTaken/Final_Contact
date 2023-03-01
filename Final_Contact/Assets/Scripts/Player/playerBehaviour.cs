using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class playerBehaviour : MonoBehaviour
{
    public float health;
    [SerializeField]
    private float maxHealth;
    public Image healthBar;
    public bool downed;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            GetComponent<PlayerController>().Down();
        }
    }
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
        if (other.gameObject.CompareTag("PickupFiringSpeed"))
        {
            gameObject.GetComponentInChildren<WeaponManager>().FiringSpeedBonus(other.gameObject);
        }
        if (gameObject.GetComponentInChildren<WeaponManager>().playerWeapon == WeaponManager.equippedWeapon.None)
        {
            gameObject.GetComponentInChildren<WeaponManager>().PickupWeapon(other.gameObject);
        }
    }
}

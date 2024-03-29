using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class playerBehaviour : MonoBehaviour
{
    public float health;
    [SerializeField]
    public float maxHealth;
    public Image healthBar;
    public Image heatBar;
    public Image staminaBar;
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
        if (health <= 0 && !GetComponent<PlayerController>().downed)
        {
            GetComponent<PlayerController>().Down();
        }
        heatBar.fillAmount = Mathf.Clamp(GetComponentInChildren<WeaponManager>().heat, 0, 1);
        staminaBar.fillAmount = Mathf.Clamp(GetComponent<PlayerController>().dodgeTimePercentage, 0, 1);
        
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!GetComponent<PlayerController>().boosting)
        {
            if (other.gameObject.CompareTag("EnemyProjectile"))
            {
                health -= other.gameObject.GetComponent<EnemyMoveForward>().damage;
            }
            if (other.gameObject.CompareTag("Projectile"))
            {
                health -= other.gameObject.GetComponent<MoveForward>().damage;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupHealth"))
        {
            health += other.GetComponent<PickupHealth>().healthBonus;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        if (other.CompareTag("PickupFiringSpeed"))
        {
            gameObject.GetComponentInChildren<WeaponManager>().ActivateFiringSpeedBonus(other.gameObject);
        }
        if (gameObject.GetComponentInChildren<WeaponManager>().playerWeapon == WeaponManager.EquippedWeapon.None)
        {
            gameObject.GetComponentInChildren<WeaponManager>().PickupWeapon(other.gameObject);
        }
    }
}

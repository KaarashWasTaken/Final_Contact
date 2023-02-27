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
    public float timeFiringSpeed;
    public float originalFiringSpeed;
    public bool firingSpeedActive = false;
    public enum equipedWeapon
    {
        AR,
        none,
        shotgun,
        SMG,
        MG,
        sword
    }
    public equipedWeapon playerWeapon;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        originalFiringSpeed = gameObject.GetComponentInChildren<AR>().firingspeed;
        equipedWeapon playerWeapon = equipedWeapon.AR;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            Down();
        }
        if (firingSpeedActive && gameObject.GetComponentInChildren<AR>().firingspeed != originalFiringSpeed && Time.time > timeFiringSpeed)
        {
            gameObject.GetComponentInChildren<AR>().firingspeed = originalFiringSpeed;
            firingSpeedActive = false;
        }
    }
    public void Down()
    {
        downed = true;
        Destroy(transform.parent.gameObject);
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
        if (other.gameObject.CompareTag("PickupFiringSpeed") && !firingSpeedActive)
        {
            firingSpeedActive = true;
            gameObject.GetComponentInChildren<AR>().firingspeed = gameObject.GetComponentInChildren<AR>().firingspeed * other.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
            timeFiringSpeed = Time.time + other.gameObject.GetComponent<PickupFiringSpeed>().bonusTime;
        }
    }
    //public void Revived()
    //{

    //}
}

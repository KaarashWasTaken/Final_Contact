using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum equippedWeapon
    {
        AR,
        None,
        Shotgun,
        SMG,
        MG,
        Sword
    }
    public equippedWeapon playerWeapon;
    public GameObject AR;
    public GameObject Shotgun;
    public GameObject SMG;
    public GameObject MG;
    public float timeFiringSpeed;
    private float currentFiringSpeed;
    private float originalFiringSpeed;
    public bool firingSpeedActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = equippedWeapon.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (firingSpeedActive && currentFiringSpeed != originalFiringSpeed && Time.time > timeFiringSpeed)
        {
            if (playerWeapon == equippedWeapon.AR)
                gameObject.GetComponentInChildren<AR>().firingspeed = originalFiringSpeed;
            if (playerWeapon == equippedWeapon.Shotgun)
                gameObject.GetComponentInChildren<Shotgun>().firingspeed = originalFiringSpeed;
            firingSpeedActive = false;
        }
    }
    public void PickupWeapon(GameObject weapon)
    {
        if (weapon.gameObject.CompareTag("AR"))
        {
            AR.SetActive(true);
            playerWeapon = equippedWeapon.AR;
            originalFiringSpeed = gameObject.GetComponentInChildren<AR>().firingspeed;
        }
        else if(weapon.gameObject.CompareTag("Shotgun"))
        {
            Shotgun.SetActive(true);
            playerWeapon = equippedWeapon.Shotgun;
            originalFiringSpeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed;
        }
    }
    public void FiringSpeedBonus(GameObject pickup)
    {
        if (!firingSpeedActive)
        {
            firingSpeedActive = true;
            timeFiringSpeed = Time.time + pickup.gameObject.GetComponent<PickupFiringSpeed>().bonusTime;
            if (playerWeapon == equippedWeapon.AR)
            {
                gameObject.GetComponentInChildren<AR>().firingspeed = gameObject.GetComponentInChildren<AR>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<AR>().firingspeed;
            }
            if (playerWeapon == equippedWeapon.Shotgun)
            {
                gameObject.GetComponentInChildren<Shotgun>().firingspeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed;
            }
        }
    }
    public void shoot()
    {
        if (playerWeapon == equippedWeapon.AR)
        {
            gameObject.GetComponentInChildren<AR>().Shoot();
        }
        if (playerWeapon == equippedWeapon.Shotgun)
        {
            gameObject.GetComponentInChildren<Shotgun>().Shoot();
        }
    }
}

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
    public float heat;
    // this script handles weapon types and general effects

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = equippedWeapon.None;
    }

    // Update is called once per frame
    void Update()
    {
        //returns firing speed to normal after pickup
        if (firingSpeedActive && currentFiringSpeed != originalFiringSpeed && Time.time > timeFiringSpeed)
        {
            if (playerWeapon == equippedWeapon.AR)
                gameObject.GetComponentInChildren<AR>().firingspeed = originalFiringSpeed;
            if (playerWeapon == equippedWeapon.Shotgun)
                gameObject.GetComponentInChildren<Shotgun>().firingspeed = originalFiringSpeed;
            firingSpeedActive = false;
        }

        //gets how close the picked up weapon is to overheating
        if (playerWeapon == equippedWeapon.AR)
        {
            heat = gameObject.GetComponentInChildren<AR>().heat / gameObject.GetComponentInChildren<AR>().maxHeat;
        }
        else if (playerWeapon == equippedWeapon.Shotgun)
        {
            heat = gameObject.GetComponentInChildren<Shotgun>().heat / gameObject.GetComponentInChildren<Shotgun>().maxHeat;
        }
    }
    public void PickupWeapon(GameObject weapon)
    {
        //picks up weapons depending on tag
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
        //activates bonus firingspeed
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
        //shoots the picked up weapon
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

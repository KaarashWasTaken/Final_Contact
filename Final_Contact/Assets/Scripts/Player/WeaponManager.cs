using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : MonoBehaviour
{
    public enum EquippedWeapon
    {
        AR,
        None,
        Shotgun,
        SMG,
        MG,
        Sword
    }
    public EquippedWeapon playerWeapon;
    public GameObject AR;
    public GameObject Shotgun;
    public GameObject SMG;
    public GameObject MG;
    public float timeFiringSpeed;
    private float currentFiringSpeed;
    private float originalFiringSpeed;
    private float currentHeatEffect;
    private float originalHeatEffect;
    public bool firingSpeedActive = false;
    public float heat;
    [Header("Drop pickups")]
    public GameObject AR_Pickup;
    public GameObject Shotgun_Pickup;
    public GameObject SMG_Pickup;
    public GameObject MG_Pickup;

    [SerializeField]
    private Transform DropPoint;
    // this script handles weapon types and general effects

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = EquippedWeapon.None;
    }

    // Update is called once per frame
    void Update()
    {
        //returns firing speed to normal after pickup
        if (firingSpeedActive && currentFiringSpeed != originalFiringSpeed && Time.time > timeFiringSpeed)
        {
            if (playerWeapon == EquippedWeapon.AR)
            {
                gameObject.GetComponentInChildren<AR>().firingspeed = originalFiringSpeed;
                gameObject.GetComponentInChildren<AR>().heatEffect = originalHeatEffect;
            }
            if (playerWeapon == EquippedWeapon.Shotgun)
            {
                gameObject.GetComponentInChildren<Shotgun>().firingspeed = originalFiringSpeed;
                gameObject.GetComponentInChildren<Shotgun>().heatEffect = originalHeatEffect;
            }
            if (playerWeapon == EquippedWeapon.MG)
            {
                gameObject.GetComponentInChildren<MG>().firingspeed = originalFiringSpeed;
                gameObject.GetComponentInChildren<MG>().heatEffect = originalHeatEffect;
            }
            if (playerWeapon == EquippedWeapon.SMG)
            {
                gameObject.GetComponentInChildren<SMG>().firingspeed = originalFiringSpeed;
                gameObject.GetComponentInChildren<SMG>().heatEffect = originalHeatEffect;
            }

            firingSpeedActive = false;
        }

        //gets how close the picked up weapon is to overheating
        if (playerWeapon == EquippedWeapon.AR)
        {
            heat = gameObject.GetComponentInChildren<AR>().heat / gameObject.GetComponentInChildren<AR>().maxHeat;
        }
        else if (playerWeapon == EquippedWeapon.Shotgun)
        {
            heat = gameObject.GetComponentInChildren<Shotgun>().heat / gameObject.GetComponentInChildren<Shotgun>().maxHeat;
        }
        else if (playerWeapon == EquippedWeapon.MG)
        {
            heat = gameObject.GetComponentInChildren<MG>().heat / gameObject.GetComponentInChildren<MG>().maxHeat;
        }
        else if (playerWeapon == EquippedWeapon.SMG)
        {
            heat = gameObject.GetComponentInChildren<SMG>().heat / gameObject.GetComponentInChildren<SMG>().maxHeat;
        }
    }
    public void PickupWeapon(GameObject weapon)
    {
        //picks up weapons depending on tag
        if (weapon.gameObject.CompareTag("AR"))
        {
            AR.SetActive(true);
            playerWeapon = EquippedWeapon.AR;
            originalFiringSpeed = gameObject.GetComponentInChildren<AR>().firingspeed;
            originalHeatEffect = gameObject.GetComponentInChildren<AR>().heatEffect;
        }
        else if(weapon.gameObject.CompareTag("Shotgun"))
        {
            Shotgun.SetActive(true);
            playerWeapon = EquippedWeapon.Shotgun;
            originalFiringSpeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed;
            originalHeatEffect = gameObject.GetComponentInChildren<Shotgun>().heatEffect;
        }
        else if (weapon.gameObject.CompareTag("MG"))
        {
            MG.SetActive(true);
            playerWeapon = EquippedWeapon.MG;
            originalFiringSpeed = gameObject.GetComponentInChildren<MG>().firingspeed;
            originalHeatEffect = gameObject.GetComponentInChildren<MG>().heatEffect;
        }
        else if (weapon.gameObject.CompareTag("SMG"))
        {
            SMG.SetActive(true);
            playerWeapon = EquippedWeapon.SMG;
            originalFiringSpeed = gameObject.GetComponentInChildren<SMG>().firingspeed;
            originalHeatEffect = gameObject.GetComponentInChildren<SMG>().heatEffect;
        }
    }
    public void FiringSpeedBonus(GameObject pickup)
    {
        //activates bonus firingspeed
        if (!firingSpeedActive)
        {
            firingSpeedActive = true;
            timeFiringSpeed = Time.time + pickup.gameObject.GetComponent<PickupFiringSpeed>().bonusTime;
            if (playerWeapon == EquippedWeapon.AR)
            {
                gameObject.GetComponentInChildren<AR>().firingspeed = gameObject.GetComponentInChildren<AR>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                gameObject.GetComponentInChildren<AR>().heatEffect= gameObject.GetComponentInChildren<AR>().heatEffect * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<AR>().firingspeed;
                currentHeatEffect = gameObject.GetComponentInChildren<AR>().heatEffect;
            }
            if (playerWeapon == EquippedWeapon.Shotgun)
            {
                gameObject.GetComponentInChildren<Shotgun>().firingspeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                gameObject.GetComponentInChildren<Shotgun>().heatEffect = gameObject.GetComponentInChildren<Shotgun>().heatEffect * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<Shotgun>().firingspeed;
                currentHeatEffect = gameObject.GetComponentInChildren<Shotgun>().heatEffect;
            }
            if (playerWeapon == EquippedWeapon.MG)
            {
                gameObject.GetComponentInChildren<MG>().firingspeed = gameObject.GetComponentInChildren<MG>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                gameObject.GetComponentInChildren<MG>().heatEffect = gameObject.GetComponentInChildren<MG>().heatEffect * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<MG>().firingspeed;
                currentHeatEffect = gameObject.GetComponentInChildren<MG>().heatEffect;
            }
            if (playerWeapon == EquippedWeapon.SMG)
            {
                gameObject.GetComponentInChildren<SMG>().firingspeed = gameObject.GetComponentInChildren<SMG>().firingspeed * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                gameObject.GetComponentInChildren<SMG>().heatEffect = gameObject.GetComponentInChildren<SMG>().heatEffect * pickup.gameObject.GetComponent<PickupFiringSpeed>().firingSpeedMultiplier;
                currentFiringSpeed = gameObject.GetComponentInChildren<SMG>().firingspeed;
                currentHeatEffect = gameObject.GetComponentInChildren<SMG>().heatEffect;
            }
        }
    }
    public void Shoot()
    {
        //shoots the picked up weapon
        if (playerWeapon == EquippedWeapon.AR)
        {
            gameObject.GetComponentInChildren<AR>().Shoot();
        }
        if (playerWeapon == EquippedWeapon.Shotgun)
        {
            gameObject.GetComponentInChildren<Shotgun>().Shoot();
        }
        if (playerWeapon == EquippedWeapon.MG)
        {
            gameObject.GetComponentInChildren<MG>().Shoot();
        }
        if (playerWeapon == EquippedWeapon.SMG)
        {
            gameObject.GetComponentInChildren<SMG>().Shoot();
        }
    }
    public void Drop()
    {
        if (SceneManager.GetActiveScene().name == "Armory")
        {
            Debug.Log("drop");
            //shoots the picked up weapon
            if (playerWeapon == EquippedWeapon.AR)
            {
                AR.SetActive(false);
                playerWeapon = EquippedWeapon.None;
                originalFiringSpeed = 0;
                originalHeatEffect = 0;
                Instantiate(AR_Pickup, DropPoint.position, DropPoint.rotation);
            }
            if (playerWeapon == EquippedWeapon.Shotgun)
            {
                Shotgun.SetActive(false);
                playerWeapon = EquippedWeapon.None;
                originalFiringSpeed = 0;
                originalHeatEffect = 0;
                Instantiate(Shotgun_Pickup, DropPoint.position, DropPoint.rotation);
            }
            if (playerWeapon == EquippedWeapon.MG)
            {
                MG.SetActive(false);
                playerWeapon = EquippedWeapon.None;
                originalFiringSpeed = 0;
                originalHeatEffect = 0;
                Instantiate(MG_Pickup, DropPoint.position, DropPoint.rotation);
            }
            if (playerWeapon == EquippedWeapon.SMG)
            {
                SMG.SetActive(false);
                playerWeapon = EquippedWeapon.None;
                originalFiringSpeed = 0;
                originalHeatEffect = 0;
                Instantiate(SMG_Pickup, DropPoint.position, DropPoint.rotation);
            }
            heat = 0;
        }
    }
}

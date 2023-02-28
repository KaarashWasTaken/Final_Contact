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

    // Start is called before the first frame update
    void Start()
    {
        playerWeapon = equippedWeapon.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickupWeapon(GameObject weapon)
    {
        if (weapon.gameObject.CompareTag("AR"))
        {
            AR.SetActive(true);
            playerWeapon = equippedWeapon.AR;
        }
        else if(weapon.gameObject.CompareTag("Shotgun"))
        {
            Shotgun.SetActive(true);
            playerWeapon = equippedWeapon.Shotgun;
        }
    }
    public void shoot()
    {
        if (playerWeapon == equippedWeapon.AR)
        {
            gameObject.GetComponentInChildren<AR>().Shoot();
        }
    }
}

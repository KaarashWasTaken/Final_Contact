using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    UpgradeManager manager;
    public GameObject upgradeMenu;
    public GameObject player;
    WeaponManager weaponManager;
    public GameObject[] buttons;
    private void Update()
    {
        if(upgradeMenu.activeSelf)
        {
            CheckIfButtonSelected();
        }
    }
    private void CheckIfButtonSelected()
    {
        if(EventSystem.current.currentSelectedGameObject == null)
        {   
            for(int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].activeSelf)
                {
                    EventSystem.current.SetSelectedGameObject(buttons[i].gameObject);
                }
            }
        }
    }
    public void Activate()
    {
        manager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        upgradeMenu.SetActive(true);
        weaponManager = player.GetComponentInChildren<WeaponManager>();
    }

    // Update is called once per frame
    public void DMGUpgrade()
    {
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.AR)
        {
            weaponManager.gameObject.GetComponentInChildren<AR>().damage += 4f;
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.Shotgun)
        {
            weaponManager.gameObject.GetComponentInChildren<Shotgun>().damage += 3f;
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.MG)
        {
            weaponManager.gameObject.GetComponentInChildren<MG>().damage += 2.5f;
        }
        if (weaponManager.playerWeapon == WeaponManager.EquippedWeapon.SMG)
        {
            weaponManager.gameObject.GetComponentInChildren<SMG>().damage += 3f;
        }
        manager.SetDMGInactive();
        upgradeMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void HPUpgrade()
    {
        player.GetComponent<playerBehaviour>().health += 20;
        upgradeMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        manager.SetHPInactive();
    }
    public void HeatUpgrade()
    {
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.AR)
        {
            weaponManager.gameObject.GetComponentInChildren<AR>().heatEffect *= 0.9f;
        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.Shotgun)
        {
            weaponManager.gameObject.GetComponentInChildren<Shotgun>().heatEffect *= 0.9f;

        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.MG)
        {
            weaponManager.gameObject.GetComponentInChildren<MG>().heatEffect *= 0.9f;

        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.SMG)
        {
            weaponManager.gameObject.GetComponentInChildren<SMG>().heatEffect *= 0.9f;
        }
        upgradeMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        manager.SetHeatInactive();
    }
    public void DodgeCDUpgrade()
    {
        player.GetComponent<PlayerController>().dodgeCD *= 0.85f;
        upgradeMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        manager.SetDodgeCDInactive();
    }
}

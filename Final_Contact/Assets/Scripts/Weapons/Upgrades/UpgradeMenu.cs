using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    UpgradeManager manager;
    public EventSystem eventSystem;
    public GameObject upgradeMenu;
    public GameObject player;
    WeaponManager weaponManager;
    public GameObject[] buttons;
    public bool upgradeMenuOpen;
    private void Update()
    {
        Debug.Log(upgradeMenu.activeSelf + " menu state");
        if(upgradeMenu.activeSelf)
        {
            upgradeMenuOpen= true;
            CheckIfButtonSelected();
        }
    }
    private void CheckIfButtonSelected()
    {
        Debug.Log(eventSystem.currentSelectedGameObject.activeSelf + " button state");
        if(eventSystem.currentSelectedGameObject == null || !eventSystem.currentSelectedGameObject.activeSelf)
        {
            Debug.Log("none selected");
            for(int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].activeSelf)
                {
                    eventSystem.SetSelectedGameObject(buttons[i]);
                    break;
                }
            }
        }
    }
    public void Activate()
    {
        manager = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        upgradeMenu.SetActive(true);
        weaponManager = player.GetComponentInChildren<WeaponManager>();
        foreach (GameObject g in buttons)
            if(!g.activeSelf)
                g.SetActive(true);
        eventSystem.SetSelectedGameObject(buttons[0]);
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
        MenuClose();
    }
    public void HPUpgrade()
    {
        player.GetComponent<playerBehaviour>().maxHealth += 25;
        player.GetComponent<playerBehaviour>().health += 25;
        manager.SetHPInactive();
        MenuClose();
    }
    public void HeatUpgrade()
    {
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.AR)
        {
            weaponManager.gameObject.GetComponentInChildren<AR>().heatEffect *= 0.8f;
        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.Shotgun)
        {
            weaponManager.gameObject.GetComponentInChildren<Shotgun>().heatEffect *= 0.8f;

        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.MG)
        {
            weaponManager.gameObject.GetComponentInChildren<MG>().heatEffect *= 0.8f;

        }
        if(weaponManager.playerWeapon == WeaponManager.EquippedWeapon.SMG)
        {
            weaponManager.gameObject.GetComponentInChildren<SMG>().heatEffect *= 0.8f;
        }
        manager.SetHeatInactive();
        MenuClose();
    }
    public void DodgeCDUpgrade()
    {
        player.GetComponent<PlayerController>().dodgeCD *= 0.8f;
        manager.SetDodgeCDInactive();
        MenuClose();
    }
    private void MenuClose()
    {
        upgradeMenuOpen = false;
        upgradeMenu.SetActive(false);
        eventSystem.SetSelectedGameObject(null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    GameObject[] playerMenu;
    public static bool upgradeMenuOpened= false;
    public static bool inArmory;

    // Update is called once per frame
    void Update()
    {
        if (!inArmory && SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (GameObject.Find("EnemyManager").GetComponent<EnemyManager>().enemyLevelCount <= 0 && !upgradeMenuOpened && !EnemyManager.firstSpawn)
            {
                SetMenuActive();
                upgradeMenuOpened = true;
            }
        }
    }
    public void SetMenuActive()
    {
        playerMenu = GameObject.FindGameObjectsWithTag("UpgradeMenu");
        foreach (GameObject g in playerMenu)
        {
            g.GetComponent<UpgradeMenu>().Activate();
        }
    }
    public void SetDMGInactive()
    {
        foreach (GameObject g in playerMenu)
        {
            if (g.GetComponent<UpgradeMenu>().upgradeMenuOpen)
                GameObject.Find("DMG").SetActive(false);
        }
    }
    public void SetHPInactive()
    {
        foreach (GameObject g in playerMenu)
        {
            if (g.GetComponent<UpgradeMenu>().upgradeMenuOpen)
                GameObject.Find("HP").SetActive(false);
        }
    }
    public void SetHeatInactive()
    {
        foreach (GameObject g in playerMenu)
        {
            if (g.GetComponent<UpgradeMenu>().upgradeMenuOpen)
                GameObject.Find("HEAT").SetActive(false);
        }
    }
    public void SetDodgeCDInactive()
    {
        foreach (GameObject g in playerMenu)
        {
            if (g.GetComponent<UpgradeMenu>().upgradeMenuOpen)
                GameObject.Find("DODGECD").SetActive(false);
        }
    }
}

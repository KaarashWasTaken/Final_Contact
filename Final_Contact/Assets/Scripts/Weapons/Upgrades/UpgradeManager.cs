using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    public GameObject[] upgrades;
    GameObject[] playerMenu;
    public bool upgradeMenuOpened= false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("EnemyManager").GetComponent<EnemyManager>().enemyLevelCount <= 0 && !upgradeMenuOpened)
        {
            SetMenuActive();
            upgradeMenuOpened = true;
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
        for (int i = 0; i < playerMenu.Length; i++)
        {
            GameObject.Find("DMG").SetActive(false);
        }
    }
    public void SetHPInactive()
    {
        for (int i = 0; i < playerMenu.Length; i++)
        {
            GameObject.Find("HP").SetActive(false);
        }
    }
    public void SetHeatInactive()
    {
        for (int i = 0; i < playerMenu.Length; i++)
        {
            GameObject.Find("HEAT").SetActive(false);
        }
    }
    public void SetDodgeCDInactive()
    {
        for (int i = 0; i < playerMenu.Length; i++)
        {
            GameObject.Find("DODGECD").SetActive(false);
        }
    }
    //private void 
}

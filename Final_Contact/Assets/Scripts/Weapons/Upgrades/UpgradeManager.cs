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
        foreach (GameObject g in playerMenu)
        {
            GameObject.Find("DMG").SetActive(false);
        }
    }
    public void SetHPInactive()
    {

    }
    public void SetHeatInactive()
    {

    }
    public void SetDodgeCDInactive()
    {

    }
    //private void 
}

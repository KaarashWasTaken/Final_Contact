using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeManager : MonoBehaviour
{
    public GameObject[] upgrades;
    public bool upgradeMenuOpened= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("EnemyManager").GetComponent<EnemyManager>().enemyLevelCount <= 0 && !upgradeMenuOpened)
        {
            upgradeMenuOpened = true;
        }
    }
    private void SetMenuActive()
    {
        GameObject[] playerMenu = GameObject.FindGameObjectsWithTag("UpgradeMenu");
        foreach (GameObject g in playerMenu)
        {
            g.GetComponent<UpgradeMenu>().Activate();
        }
    }
    //private void 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesKilled : MonoBehaviour
{
    public static bool opened = false;
    public GameObject clearedCanvas;
    // Update is called once per frame
    void Update()
    {
        if(!UpgradeManager.inArmory)
        {
            if(GameObject.Find("EnemyManager").GetComponent<EnemyManager>().enemyLevelCount <= 0 && !opened)
            {
                opened= true;
                clearedCanvas.SetActive(true);
                Invoke(nameof(CloseCanvas), 5);
            }
        }
    }
    private void CloseCanvas()
    {
        clearedCanvas.SetActive(false);
    }
}

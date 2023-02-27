using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    EnemyManager enemyManager;
    private int readyPlayers;
    private int nrOfPlayers;

    // Start is called before the first frame update
    void Awake()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (other.CompareTag("Player") && enemyManager.enemyLevelCount <= 0 && !other.GetComponent<PlayerController>().ready)
        {
            other.GetComponent<PlayerController>().ready = true;
            readyPlayers++;
            Debug.Log("Player ready");
            if (readyPlayers >= nrOfPlayers + 1)
            {
                //SceneManager.LoadScene("CombatScene");
                Debug.Log("Next Level");
            }
            //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //if (SceneManager.sceneCount > nextSceneIndex)
            //{
            //    SceneManager.LoadScene(nextSceneIndex);
            //}
        }
        else if (other.CompareTag("Player") && enemyManager.enemyLevelCount > 0)
        {
            Debug.Log("Kill all enemies to progress");
        }
    }
}
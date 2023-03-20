using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private int readyPlayers;
    [SerializeField]
    private int nrOfPlayers;
    private EnemyManager enemyManager;
    private bool popupActive = false;
    public GameObject enemiesPopup;
    private void OnTriggerEnter(Collider other)
    {
        //Sets the value of nrOfPlayers to the amount of objects that have the tag Player
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        //Checks if the trigger is a player, if the player isn't ready and if the player has a weapon equipped
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().ready && enemyManager.enemyLevelCount <= 0)
        {
            //Sets the bool ready in PlayerController to true
            other.GetComponent<PlayerController>().ready = true;
            readyPlayers++;//Adds 1 to readyPlayers
            //If all players are ready the following if statement is run
            if (readyPlayers >= nrOfPlayers)
            {
                //Opens level select menu
                GameObject.FindWithTag("LevelSelect").GetComponent<NextLevelSelect>().Selection();
                Debug.Log("Choose Level");
            }
        }
        else if(other.CompareTag("Player") && enemyManager.enemyLevelCount > 0 && !popupActive)
        {
            Invoke(nameof(KillEnemiesPopup), 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //If a player leaves the ready zone and is ready
        if (other.CompareTag("Player") && other.GetComponent<PlayerController>().ready)
        {
            //Sets the bool ready in PlayerController to false
            other.GetComponent<PlayerController>().ready = false;
            //Decreases the amount of readyplayers by 1
            readyPlayers--;
        }
    }
    private void KillEnemiesPopup()
    {
        popupActive = true;
        enemiesPopup.SetActive(true);
        Invoke(nameof(EndPopup), 5);
    }
    private void EndPopup()
    {
        popupActive = false;
        enemiesPopup.SetActive(false);
    }
}
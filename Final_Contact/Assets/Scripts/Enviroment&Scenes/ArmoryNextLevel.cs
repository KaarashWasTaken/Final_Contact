using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmoryNextLevel : MonoBehaviour
{
    [SerializeField]
    private int readyPlayers;
    [SerializeField]
    private int nrOfPlayers;
    private void OnTriggerEnter(Collider other)
    {
        //Sets the value of nrOfPlayers to the amount of objects that have the tag Player
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        //Checks if the trigger is a player, if the player isn't ready and if the player has a weapon equipped
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().ready && other.gameObject.GetComponentInChildren<WeaponManager>().playerWeapon != WeaponManager.EquippedWeapon.None)
        {
            //Sets the bool ready in PlayerController to true
            other.GetComponent<PlayerController>().ready = true;
            readyPlayers++;//Adds 1 to readyPlayers
            GameObject[] downedPlayers = GameObject.FindGameObjectsWithTag("PlayerDown");
            //If all players are ready the following if statement is run
            if (readyPlayers >= nrOfPlayers && downedPlayers.Length <= 0)
            {
                //Opens level select menu
                GameObject.FindWithTag("LevelSelect").GetComponent<NextLevelSelect>().Selection();
                Debug.Log("Choose Level");
            }
            Debug.Log("Player ready");
            //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //if (SceneManager.sceneCount > nextSceneIndex)
            //{
            //    SceneManager.LoadScene(nextSceneIndex);
            //}
            //CheckIfReady();
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        //If a player leaves the ready zone and is ready
        if(other.CompareTag("Player") && other.GetComponent<PlayerController>().ready)
        {
            //Sets the bool ready in PlayerController to false
            other.GetComponent<PlayerController>().ready = false;
            //Decreases the amount of readyplayers by 1
            readyPlayers--;
            Debug.Log("Player Unready");
        }
    }
}
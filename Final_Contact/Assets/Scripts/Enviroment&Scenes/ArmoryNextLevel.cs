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
    GameObject[] Players;
    GameObject[] ReadyPlayers;
    private void OnTriggerEnter(Collider other)
    {
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().ready)
        {
            other.GetComponent<PlayerController>().ready = true;
            readyPlayers++;
            if (readyPlayers >= nrOfPlayers)
            {
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
        if(other.CompareTag("Player") && other.GetComponent<PlayerController>().ready)
        {
            other.GetComponent<PlayerController>().ready = false;
            readyPlayers--;
            Debug.Log("Player Unready");
        }
    }
    //private void CheckIfReady()
    //{
    //    GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
    //    foreach(GameObject g in Players)
    //    {
    //        if(g.GetComponent<PlayerController>().ready)
    //        {

    //        }
    //    }
    //}
}
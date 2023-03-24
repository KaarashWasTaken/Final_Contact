using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPopup : MonoBehaviour
{
    int nrOfPlayers;
    public GameObject Popup;
    void Update()
    {
        //tells the player to press a to spawn if noone has spawned
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (nrOfPlayers != 0)
        {
            Destroy(Popup);
        }
        
    }
}

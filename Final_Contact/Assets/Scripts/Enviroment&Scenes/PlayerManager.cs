using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerManager;
    private GameObject[] players;
    private GameObject[] downedPlayers;
    private float nrOfPlayers;
    private GameObject gameOver;
    // Start is called before the first frame update
    private void Awake()
    {
        playerManager = GetComponent<PlayerInputManager>();
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameOver = GameObject.FindWithTag("GameOver");
        Debug.Log("OnSceneLoaded: " + scene.name);
        scene = SceneManager.GetActiveScene();
        //Diables joining when the scene is not armory
        if (scene.name != "Armory")
            playerManager.DisableJoining();
        if (scene.name == "Armory")
            playerManager.EnableJoining();
        players = GameObject.FindGameObjectsWithTag("Player");
        //Loops through the players and set them to unready
        foreach (GameObject g in players)
            g.GetComponent<PlayerController>().ready = false;
    }
    public void CheckIfAllDown()
    {
        downedPlayers = GameObject.FindGameObjectsWithTag("Player");
        if(downedPlayers.Length <= 0)
        {
            Debug.Log("GameOver");
            //insert Gameover script here
            GameObject.FindWithTag("GameOver").GetComponent<GameOver>().Activate();
        }
    }
}

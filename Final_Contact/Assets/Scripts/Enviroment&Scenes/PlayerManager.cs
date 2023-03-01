using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerManager;
    private GameObject[] players;
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
        Debug.Log("OnSceneLoaded: " + scene.name);
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Armory")
            playerManager.DisableJoining();
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in players)
            g.GetComponent<PlayerController>().ready = false;
    }
}

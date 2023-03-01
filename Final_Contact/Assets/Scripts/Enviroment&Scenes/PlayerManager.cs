using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Scene scene;
    PlayerInputManager playerManager;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        playerManager = GetComponent<PlayerInputManager>();
    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Armory")
            playerManager.DisableJoining();
    }
}

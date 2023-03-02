using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Scene scene;
    public PlayerInputManager playerManager;
    bool leftArmory=false;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Armory" && !leftArmory)
        {
            playerManager.DisableJoining();
            leftArmory= true;
        }   
    }
}

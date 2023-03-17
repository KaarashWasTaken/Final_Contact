using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerManager;
    private GameObject[] players;
    private GameObject[] downedPlayers;
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
        //Disables joining when the scene is not armory
        //if (scene.name != "LVLArmory")
        //    playerManager.DisableJoining();
        //if (scene.name == "LVLArmory")
        //    playerManager.EnableJoining();
        players = GameObject.FindGameObjectsWithTag("Player");
        //Loops through the players and set them to unready
        foreach (GameObject g in players)
        {
            g.GetComponent<PlayerController>().ready = false;
            g.GetComponent<PlayerController>().StartPos();
            g.GetComponent<playerBehaviour>().health = g.GetComponent<playerBehaviour>().maxHealth;
        }
        GameObject[] upgradeMenuButtons = GameObject.FindGameObjectsWithTag("UpgradeMenuButton");
        foreach (GameObject g in upgradeMenuButtons)
            g.SetActive(true);

    }
    public void CheckIfAllDown()
    {
        downedPlayers = GameObject.FindGameObjectsWithTag("Player");
        if(downedPlayers.Length <= 0)
        {
            Debug.Log("GameOver");
            GameObject.FindWithTag("GameOver").GetComponent<GameOver>().Activate();
        }
    }
}

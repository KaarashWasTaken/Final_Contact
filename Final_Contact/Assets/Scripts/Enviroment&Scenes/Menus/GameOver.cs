using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject firstbutton;
    private void Start()
    {
        gameOverUI.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }
    public void Activate()
    {
        gameOverUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstbutton);
    }
    public void Restart()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players) 
        {
            Destroy(player.transform.parent.gameObject);
        }
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("Armory");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void MainMenu()
    {

    }
}

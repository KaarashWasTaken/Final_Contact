using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject firstbutton;
    public GameObject eventSystem;
    public EventSystem eventSystemUI;
    private void Awake()
    {
        eventSystem.SetActive(false);
        gameOverUI.SetActive(false);
    }
    public void Activate()
    {
        eventSystem.SetActive(true);
        gameOverUI.SetActive(true);
        eventSystemUI.SetSelectedGameObject(firstbutton);
    }
    public void Restart()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players) 
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("Menus"));
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("LVLArmory");
    }
    public void MainMenu()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players)
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("Menus"));
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    public GameObject firstButton;
    public GameObject eventSystem;
    public EventSystem eventSystemUI;
    private void Update()
    {
        if (paused) 
        {
            Time.timeScale = 0f;
        }
    }
    public void Restart()
    {
        //restarting the game from armory
        Time.timeScale = 1f;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player.transform.parent.gameObject);
        }
        GameObject[] playersDowned = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in playersDowned)
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("Menus"));
        pauseMenuUI.SetActive(false);
        eventSystem.SetActive(false);
        SceneManager.LoadScene("LVLArmory");
        paused = false;

    }
    public void Pause()
    {
        //pauses game by using timescale set to zero
        eventSystem.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        eventSystemUI.SetSelectedGameObject(firstButton);
    }
    public void Continue()
    {
        //removes pause screen and sets timescale to 1
        pauseMenuUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
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
        SceneManager.LoadScene("MainMenu");
        eventSystemUI.SetSelectedGameObject(null);
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
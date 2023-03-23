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

    public void Pause()
    {
        eventSystem.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        eventSystemUI.SetSelectedGameObject(firstButton);
    }
    public void Continue()
    {
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
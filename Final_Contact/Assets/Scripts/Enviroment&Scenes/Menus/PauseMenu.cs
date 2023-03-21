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
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (paused) 
        {
            Time.timeScale = 0f;
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void MainMenu()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players)
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("EventSystem"));
        Destroy(GameObject.Find("UpgradeManager"));
        Destroy(GameObject.Find("Pause"));
        Destroy(GameObject.Find("GameOver"));
        SceneManager.LoadScene("MainMenu");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
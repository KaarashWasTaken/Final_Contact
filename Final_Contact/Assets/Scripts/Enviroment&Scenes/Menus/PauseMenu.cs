using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;
    public GameObject firstButton;
    private void Awake()
    {
        DontDestroyOnLoad(this);
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
        Time.timeScale = 1f;
        paused = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
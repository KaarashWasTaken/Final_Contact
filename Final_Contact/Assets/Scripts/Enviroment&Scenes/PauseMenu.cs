using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.InputSystem;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenuUI;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

    }
    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;

    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartPlaying()
    {
        SceneManager.LoadScene("Armory");
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void StartPlaying()
    {
        SceneManager.LoadScene("LVLArmory");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class WinMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject credits;
    public GameObject MainMenuButton;
    public GameObject CreditsButton;
    public GameObject RemoveCreditsButton;
    public GameObject QuitButton;
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void LoadCredits()
    {
        credits.SetActive(true);
        RemoveCreditsButton.SetActive(true);
        MainMenuButton.SetActive(false);
        CreditsButton.SetActive(false);
        QuitButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(RemoveCreditsButton);
    }
    public void DeloadCredits()
    {
        credits.SetActive(false);
        RemoveCreditsButton.SetActive(false);
        MainMenuButton.SetActive(true);
        CreditsButton.SetActive(true);
        QuitButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);

    }

    public void StopPlaying()
    {
        Application.Quit();
    }
}

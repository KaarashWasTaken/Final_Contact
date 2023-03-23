using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject credits;
    public GameObject CreditsButton;
    public GameObject RemoveCreditsButton;
    public GameObject QuitButton;
    public GameObject PlayButton;
    private void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void LoadCredits()
    {
        //shows credits and pops up a button to get you back
        credits.SetActive(true);
        RemoveCreditsButton.SetActive(true);
        PlayButton.SetActive(false);
        CreditsButton.SetActive(false);
        QuitButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(RemoveCreditsButton);
    }
    public void DeloadCredits()
    {
        //shows all buttons an removes credits
        credits.SetActive(false);
        RemoveCreditsButton.SetActive(false);
        PlayButton.SetActive(true);
        CreditsButton.SetActive(true);
        QuitButton.SetActive(true);
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
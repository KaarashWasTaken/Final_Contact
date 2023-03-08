using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class NextLevelSelect : MonoBehaviour
{
    public GameObject levelMenuUI;
    public GameObject firstButton;
    public void Selection()
    {
        levelMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
        Time.timeScale = 0f;
    }
    public void NextLevel1A()
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("1A");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel1B() 
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("1B");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void NextLevelMiniBoss()
    {
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MiniBoss");
        EventSystem.current.SetSelectedGameObject(null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class NextLevelSelect : MonoBehaviour
{
    public GameObject[] levelMenuUI;
    public GameObject eventSystem;
    public EventSystem eventSystemUI;
    public GameObject[] firstButton;
    private int i;
    private void Start()
    {
        i = 0;
    }
    public void Selection()
    {
        eventSystem.SetActive(true);
        levelMenuUI[i].SetActive(true);
        eventSystemUI.SetSelectedGameObject(firstButton[i]);
        Time.timeScale = 0f;
    }
    public void NextLevel1A()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Left");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel1B()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Right");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel2A()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Left");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel2B()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Right");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }

    public void NextLevelMiniBoss()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL3Miniboss");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel4A()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Left");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel4B()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Right");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel5A()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Left");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevel5B()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Right");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
        i++;
    }
    public void NextLevelBoss()
    {
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL6Boss");
        eventSystemUI.SetSelectedGameObject(null);
        eventSystem.SetActive(false);
    }
}

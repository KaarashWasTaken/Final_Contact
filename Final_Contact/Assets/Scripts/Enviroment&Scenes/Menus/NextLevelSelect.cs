using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class NextLevelSelect : MonoBehaviour
{
    public GameObject[] levelMenuUI;
    public GameObject eventSystem;
    public GameObject firstButton;
    private int i;
    private void Start()
    {
        i = 0;
    }
    public void Selection()
    {
        eventSystem.SetActive(true);
        levelMenuUI[i].SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
        Time.timeScale = 0f;
    }
    public void NextLevel1A()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Left");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel1B()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Right");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel2A()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Left");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel2B()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Right");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }

    public void NextLevelMiniBoss()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL3Miniboss");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel4A()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Left");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel4B()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Right");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel5A()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Left");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevel5B()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Right");
        EventSystem.current.SetSelectedGameObject(null);
        i++;
    }
    public void NextLevelBoss()
    {
        eventSystem.SetActive(false);
        levelMenuUI[i].SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL6Boss");
        EventSystem.current.SetSelectedGameObject(null);
    }
}

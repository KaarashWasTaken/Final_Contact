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
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Left");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel1B() 
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL1Right");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel2A()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Left");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel2B()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL2Right");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void NextLevelMiniBoss()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL3Miniboss");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel4A()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Left");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel4B()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL4Right");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel5A()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Left");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevel5B()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL5Right");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void NextLevelBoss()
    {
        Destroy(gameObject);
        levelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LVL6Boss");
        EventSystem.current.SetSelectedGameObject(null);
    }
}

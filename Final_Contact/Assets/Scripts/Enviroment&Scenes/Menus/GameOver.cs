using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject firstbutton;
    private void Awake()
    {
        gameOverUI.SetActive(false);
    }
    public void Activate()
    {
        gameOverUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstbutton);
    }
    public void Restart()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players) 
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("EventSystem"));
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("Pause"));
        Destroy(GameObject.Find("UpgradeManager"));
        gameOverUI.SetActive(false);
        Destroy(GameObject.Find("GameOver"));
        SceneManager.LoadScene("LVLArmory");
    }
    public void MainMenu()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerDown");
        foreach (GameObject player in players)
        {
            Destroy(player.transform.parent.gameObject);
        }
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("EventSystem"));
        Destroy(GameObject.Find("UpgradeManager"));
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void StopPlaying()
    {
        Application.Quit();
    }
}

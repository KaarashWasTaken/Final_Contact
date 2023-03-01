using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class NextLevel : MonoBehaviour
{
    EnemyManager enemyManager;
    private int readyPlayers;
    private int nrOfPlayers;

    // Start is called before the first frame update
    void Awake()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        nrOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (other.CompareTag("Player") && enemyManager.enemyLevelCount <= 0 && !other.GetComponent<PlayerController>().ready)
        {
            other.GetComponent<PlayerController>().ready = true;
            readyPlayers++;
            Debug.Log("Player ready");
            if (readyPlayers >= nrOfPlayers + 1)
            {
                //SceneManager.LoadScene("CombatScene");
                Debug.Log("Next Level");
            }
            //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //if (SceneManager.sceneCount > nextSceneIndex)
            //{
            //    SceneManager.LoadScene(nextSceneIndex);
            //}

            //public static bool paused = false;
            //public GameObject pauseMenuUI;
            // Update is called once per frame
            //    void Update()
            //    {
            //        if (Input.GetKeyDown(KeyCode.Escape))
            //        {
            //            if (paused)
            //            {
            //                Continue();
            //            }
            //            else
            //            {
            //                Pause();
            //            }
            //        }
            //    }
            //    public void Pause()
            //    {
            //        pauseMenuUI.SetActive(true);
            //        Time.timeScale = 0f;
            //        paused = true;
            //    }
            //    public void Continue()
            //    {
            //        pauseMenuUI.SetActive(false);
            //        Time.timeScale = 1f;
            //        paused = false;
            //    }
            //    public void StopPlaying()
            //    {
            //        Application.Quit();
            //    }
            //}
            else if (other.CompareTag("Player") && enemyManager.enemyLevelCount > 0)
            {
                Debug.Log("Kill all enemies to progress");
            }
        }
    }
}
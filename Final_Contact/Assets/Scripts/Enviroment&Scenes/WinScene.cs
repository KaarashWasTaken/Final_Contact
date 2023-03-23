using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.Find("sk_AlienBoss").GetComponent<EnemyBossStandard>().health <= 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players)
            {
                Destroy(player.transform.parent.gameObject);
            }
            GameObject[] playersDowned = GameObject.FindGameObjectsWithTag("PlayerDown");
            foreach (GameObject player in playersDowned)
            {
                Destroy(player.transform.parent.gameObject);
            }
            Destroy(GameObject.Find("PlayerManager"));
            Destroy(GameObject.Find("Menus"));
            SceneManager.LoadScene("WinScene");
        }
    }
}

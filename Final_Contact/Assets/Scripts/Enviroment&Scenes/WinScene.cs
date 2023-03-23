using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.Find("sk_AlienBoss").GetComponent<EnemyBossStandard>().health == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

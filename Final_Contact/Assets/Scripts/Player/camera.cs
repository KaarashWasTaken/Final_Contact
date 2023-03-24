using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, 30, -8);
        if (UpgradeManager.inArmory)
        {
            if (GameObject.FindGameObjectsWithTag("PlayerCamera").Length == 2)
            {
                transform.localScale = new(0.5f, 1, 1);
            }
            
            else if (GameObject.FindGameObjectsWithTag("PlayerCamera").Length >= 3)
                transform.localScale = new(0.5f, 0.5f, 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, 30, -8);
    }
}

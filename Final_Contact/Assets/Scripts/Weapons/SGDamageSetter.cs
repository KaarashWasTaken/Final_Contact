using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGDamageSetter : MonoBehaviour
{
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GameObject.Find("Shotgun").GetComponent<Shotgun>().damage;
        GetComponent<MoveForward>().damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

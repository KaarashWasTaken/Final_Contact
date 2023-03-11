using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGDamageSetter : MonoBehaviour
{
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GameObject.FindGameObjectWithTag("SMG").GetComponent<SMG>().damage;
        GetComponent<MoveForward>().damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

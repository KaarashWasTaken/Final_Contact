using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGDamageSetter : MonoBehaviour
{
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GameObject.Find("MG").GetComponent<MG>().damage;
        GetComponent<MoveForward>().damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

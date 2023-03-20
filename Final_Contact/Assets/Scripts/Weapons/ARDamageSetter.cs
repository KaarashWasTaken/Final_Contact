using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDamageSetter : MonoBehaviour
{
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GameObject.Find("AR").GetComponent<AR>().damage;
        GetComponent<MoveForward>().damage = damage;
    }
}

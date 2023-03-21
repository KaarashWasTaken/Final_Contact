using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    private float reviveTimer = 0;
    private float reviveBaseTime;
    public bool reviving = false;
    [SerializeField]
    private float timeToRevive = 3;
    private void Update()
    {
        if (reviving == true)
        {
            reviveTimer = Time.time - reviveBaseTime;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //timer Start
        if (other.gameObject.CompareTag("Player"))
        {
            reviveBaseTime = Time.time;
            reviving = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        //Timer reset to 0
        if (other.gameObject.CompareTag("Player"))
        {
            reviving = false;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && reviveTimer > timeToRevive)
        {
            GetComponentInParent<PlayerController>().gettingUp = true;
            GetComponentInParent<PlayerController>().downed = false;
            reviving = false;
            reviveTimer = 0;
            gameObject.GetComponentInParent<playerBehaviour>().health = 75;
            transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

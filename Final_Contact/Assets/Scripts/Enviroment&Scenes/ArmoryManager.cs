using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryManager : MonoBehaviour
{
    private float pickupHealth;
    private float pickupFiringSpeed;
    private float dummy;
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private GameObject fireRatePrefab;
    [SerializeField]
    private GameObject dummyPrefab;
    [SerializeField]
    private Transform[] pickupSpawnPoints;
    private void Start()
    {
        Instantiate(dummyPrefab, new Vector3(40,2.5f,0), Quaternion.Euler(0,270,0));
        Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);
        Instantiate(fireRatePrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);    
    }
    // Update is called once per frame
    void Update()
    {
        pickupHealth = GameObject.FindGameObjectsWithTag("PickupHealth").Length;
        pickupFiringSpeed = GameObject.FindGameObjectsWithTag("PickupFiringSpeed").Length;
        dummy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(pickupHealth < 1)
        {
            RespawnHealthPickup();
        }
        if (pickupFiringSpeed < 1)
        {
            RespawnFirePickup();
        }
        if (dummy  < 1)
        {
            RespawnDummy();
        }
    }
    private void RespawnHealthPickup()
    {
        float timeSinceDeath;
        timeSinceDeath = Time.time;
        if (Time.time > timeSinceDeath + 5)
            Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);
            
    }
    private void RespawnFirePickup()
    {
        float timeSinceDeath;
        timeSinceDeath = Time.time;
        if (Time.time > timeSinceDeath + 5)
            Instantiate(fireRatePrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);
            
    }
    private void RespawnDummy()
    {
        float timeSinceDeath;
        timeSinceDeath = Time.time;
        if(Time.time > timeSinceDeath + 5)
            Instantiate(dummyPrefab, new Vector3(40,2.5f,0), Quaternion.Euler(0,270,0));
    }
}

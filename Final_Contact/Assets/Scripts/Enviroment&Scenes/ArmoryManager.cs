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
    private bool respawningHealth = false;
    private bool respawningFirerate = false;
    private bool respawningDummy = false;
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
        if(pickupHealth < 1 && !respawningHealth)
        {
            Invoke(nameof(RespawnHealthPickup), 5);
            respawningHealth= true;
        }
        if (pickupFiringSpeed < 1 && !respawningFirerate)
        {
            Invoke(nameof(RespawnFireRatePickup), 5);
            respawningFirerate = true;
        }
        if (dummy  < 1 && !respawningDummy)
        {
            Invoke(nameof(RespawnDummy), 5);
            respawningDummy = true;
        }
    }
    private void RespawnHealthPickup()
    {
        Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);    
        respawningHealth = false;
    }
    private void RespawnFireRatePickup()
    {
        Instantiate(fireRatePrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);
        respawningFirerate = false;
    }
    private void RespawnDummy()
    {
        Instantiate(dummyPrefab, new Vector3(40,2.5f,0), Quaternion.Euler(0,270,0));
        respawningDummy = false;
    }
}

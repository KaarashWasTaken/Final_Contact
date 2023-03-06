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
        Instantiate(dummyPrefab, new Vector3(40,0,0), Quaternion.Euler(0,270,0));
        Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);
        Instantiate(fireRatePrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);    
    }
    // Update is called once per frame
    void Update()
    {
        //Look how many health pickups are active in the scene
        pickupHealth = GameObject.FindGameObjectsWithTag("PickupHealth").Length;
        //Look how many firerate pickups are active in the scene
        pickupFiringSpeed = GameObject.FindGameObjectsWithTag("PickupFiringSpeed").Length;
        //Look how many dummies are active in the scene
        dummy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //If there are no health pickups and there arent any respaning pickups
        if(pickupHealth < 1 && !respawningHealth)
        {
            Invoke(nameof(RespawnHealthPickup), 5);
            respawningHealth= true;
        }
        //If there are no firerate pickups and there arent any respawning pickups
        if (pickupFiringSpeed < 1 && !respawningFirerate)
        {
            Invoke(nameof(RespawnFireRatePickup), 5);
            respawningFirerate = true;
        }
        //If there are no dummies and there arent any respawning dummies
        if (dummy  < 1 && !respawningDummy)
        {
            Invoke(nameof(RespawnDummy), 5);
            respawningDummy = true;
        }
    }
    private void RespawnHealthPickup()
    {
        //Spawns a health pickup at the southernmost pickup spawnpoint
        Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);    
        respawningHealth = false;
    }
    private void RespawnFireRatePickup()
    {
        //Spawns a firerate pickup at the northernmost pickup spawnpoint
        Instantiate(fireRatePrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);
        respawningFirerate = false;
    }
    private void RespawnDummy()
    {
        //Spawns a dummy at the given coordinates with the given rotation
        Instantiate(dummyPrefab, new Vector3(40,0,0), Quaternion.Euler(0,270,0));
        respawningDummy = false;
    }
}

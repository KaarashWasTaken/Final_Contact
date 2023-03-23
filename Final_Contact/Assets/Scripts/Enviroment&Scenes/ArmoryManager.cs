using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryManager : MonoBehaviour
{
    private float pickupHealth;
    private float pickupFiringSpeed;
    private float dummy;
    private float mine;
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private GameObject fireRatePrefab;
    [SerializeField]
    private GameObject dummyPrefab;
    [SerializeField]
    private GameObject minePrefab;
    [SerializeField]
    private Transform[] spawnPoints;
    private bool respawningHealth = false;
    private bool respawningFirerate = false;
    private bool respawningDummy = false;
    private bool respawningMine = false;
    private Vector3 dummySpawnLocation = new(11.5f, 0, -55);
    private void Start()
    {
        //spawns thing that you can destroy in armory
        Instantiate(minePrefab, spawnPoints[3].transform.position, Quaternion.Euler(0, 270, 0));
        Instantiate(dummyPrefab, spawnPoints[2].transform.position, Quaternion.Euler(0,270,0));
        Instantiate(healthPrefab, spawnPoints[1].transform.position, Quaternion.identity);
        Instantiate(fireRatePrefab, spawnPoints[0].transform.position, Quaternion.identity);    
    }
    // Update is called once per frame
    void Update()
    {
        //Look how many health pickups are active in the scene
        mine = GameObject.FindGameObjectsWithTag("InnerWalls").Length;
        Debug.Log(mine);
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
        if (mine < 1 && !respawningMine)
        {
            Invoke(nameof(RespawnMine), 5);
            respawningMine = true;
        }
    }
    private void RespawnHealthPickup()
    {
        //Spawns a health pickup at the southernmost pickup spawnpoint
        Instantiate(healthPrefab, spawnPoints[1].transform.position, Quaternion.identity);    
        respawningHealth = false;
    }
    private void RespawnMine()
    {
        //Spawns a health pickup at the southernmost pickup spawnpoint
        Instantiate(minePrefab, spawnPoints[3].transform.position, Quaternion.identity);
        respawningMine = false;
    }
    private void RespawnFireRatePickup()
    {
        //Spawns a firerate pickup at the northernmost pickup spawnpoint
        Instantiate(fireRatePrefab, spawnPoints[0].transform.position, Quaternion.identity);
        respawningFirerate = false;
    }
    private void RespawnDummy()
    {
        //Spawns a dummy at the given coordinates with the given rotation
        Instantiate(dummyPrefab, spawnPoints[2].transform.position, Quaternion.Euler(0,270,0));
        respawningDummy = false;
    }
}

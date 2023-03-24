using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    [SerializeField]
    private Transform pickupSpawnPoint;
    [SerializeField]
    private GameObject[] pickupPrefabs;
    public bool hasPickup = false;
    private bool isSpawningPickup = false;
    public GameObject parentSpawnPoint;
    private void Start()
    {
        Invoke(nameof(SpawnPickups), Random.Range(5, 45));
    }
    public void StartSpawn()
    {
        if(!hasPickup && !isSpawningPickup)
        {
            Invoke(nameof(SpawnPickups), Random.Range(15, 35));
            isSpawningPickup = true;
        }
    }
    private void SpawnPickups()
    {
        int randomPrefab = Random.Range(0, pickupPrefabs.Length);
        GameObject Pickup = Instantiate(pickupPrefabs[randomPrefab], pickupSpawnPoint.transform.position, Quaternion.identity);
        Pickup.transform.parent = parentSpawnPoint.transform;
        hasPickup= true;
        isSpawningPickup = false;
    }
}

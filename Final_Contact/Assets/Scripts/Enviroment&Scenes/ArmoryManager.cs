using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryManager : MonoBehaviour
{
    private GameObject[] pickupHealth;
    private GameObject[] pickupFiringSpeed;
    private GameObject[] dummy;
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private GameObject fireRatePrefab;
    [SerializeField]
    private GameObject dummyPrefab;
    [SerializeField]
    private Transform[] pickupSpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        pickupHealth = GameObject.FindGameObjectsWithTag("PickupHealth");
        pickupFiringSpeed = GameObject.FindGameObjectsWithTag("PickupFiringSpeed");
        dummy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(pickupHealth.Length < 1)
        {
            Instantiate(healthPrefab, pickupSpawnPoints[1].transform.position, Quaternion.identity);
        }
        if (pickupFiringSpeed.Length < 1)
        {
            Instantiate(healthPrefab, pickupSpawnPoints[0].transform.position, Quaternion.identity);
        }
        if (dummy.Length < 1)
        {
            Instantiate(dummyPrefab, new Vector3(40,2.5f,0), Quaternion.identity);
        }
    }
}

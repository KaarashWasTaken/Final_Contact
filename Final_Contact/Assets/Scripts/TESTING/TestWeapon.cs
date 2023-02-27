using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TestWeapon : MonoBehaviour
{

    [SerializeField]
    private GameObject TestBulletPrefab;

    [SerializeField]
    private Transform Spawnpoint1;
    [SerializeField]
    private float firingspeed = 0.5f;

    private float shooting = 0;
    private float lastTimeShot = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        shooting = context.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shooting != 0)
        {
            Debug.Log("Shooting registered");
            if (lastTimeShot + firingspeed <= Time.time)
            {
                lastTimeShot = Time.time;
                Instantiate(TestBulletPrefab, Spawnpoint1.position, transform.rotation);
            }
           


            
        }

    }


    
}

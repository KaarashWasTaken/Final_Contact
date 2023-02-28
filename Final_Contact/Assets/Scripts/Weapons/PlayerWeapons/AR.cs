using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    //Shooting & aiming variables
    [SerializeField]
    public float firingspeed = 0.5f;
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    
    
    
    public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
        }
    }
    public void Activete()
    {
        gameObject.SetActive(true);
    }


}

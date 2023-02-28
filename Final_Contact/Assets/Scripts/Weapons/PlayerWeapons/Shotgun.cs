using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    //Shooting & aiming variables
    [SerializeField]
    public float firingspeed = 0.5f;
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    [SerializeField]
    private Transform FiringPoint;
    private Transform FiringPointDeviation;
    [SerializeField]
    private Rigidbody projectilePrefab;

    void Update()
    {
        FiringPointDeviation = FiringPoint;
    }

        public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            lastTimeShot = Time.time;
            //Quaternion deviation = FiringPoint.rotation;
            FiringPointDeviation = FiringPoint;

            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation.rotation);

            FiringPointDeviation.Rotate(FiringPointDeviation.position, 25);
            FiringPointDeviation.rotation.Normalize();
            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation.rotation);

            FiringPointDeviation.Rotate(FiringPointDeviation.position, -50);
            FiringPointDeviation.rotation.Normalize();
            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation.rotation);
        }
    }
}

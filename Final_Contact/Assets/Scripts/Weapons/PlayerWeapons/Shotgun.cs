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
    private float spread = 25;
    [SerializeField]
    private Transform FiringPoint;
    private Transform FiringPointDeviation;
    private Transform FiringPointDeviation1;
    private Transform FiringPointDeviation2;
    [SerializeField]
    private Rigidbody projectilePrefab;
    private Quaternion originalAngle;

    void Update()
    {
        
    }

        public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            originalAngle = FiringPoint.rotation;
            lastTimeShot = Time.time;
            //Quaternion deviation = FiringPoint.rotation;
            FiringPointDeviation = FiringPoint;
            FiringPointDeviation1 = FiringPoint;
            FiringPointDeviation2 = FiringPoint;

            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation.rotation);

            //FiringPointDeviation.Rotate(FiringPointDeviation.position, -25);
            FiringPointDeviation1.Rotate(FiringPointDeviation1.position, -spread);
            FiringPointDeviation.rotation.Normalize();
            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation1.rotation);

            FiringPointDeviation2.Rotate(FiringPointDeviation2.position, +(2 * spread));
            FiringPointDeviation.rotation.Normalize();
            Instantiate(projectilePrefab, FiringPointDeviation.position, FiringPointDeviation2.rotation);

            Debug.Log(FiringPoint.rotation.ToString());
            FiringPoint.rotation = originalAngle;
            FiringPoint.rotation.Normalize();

        }
    }
}

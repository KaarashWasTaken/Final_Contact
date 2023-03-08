using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootShotgun : MonoBehaviour
{
    [SerializeField]
    private Transform FiringPoint;
    private Transform FiringPointDeviation;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float firingspeed = 1f;
    private float lastTimeShot = 0;
    [SerializeField]
    private int numberProjectiles = 3;
    [SerializeField]
    private float spread = 35;
    private Quaternion originalAngle;

    public ParticleSystem muzzleFlash;


    private void Start()
    {
        FiringPointDeviation = FiringPoint;
    }
    public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            originalAngle = FiringPoint.rotation;
            lastTimeShot = Time.time;
            muzzleFlash.Play();
            float startAngle = -spread / 2f;
            float angleIncrease = spread / (numberProjectiles - 1);
            FiringPoint.Rotate(0, 0, startAngle);
            for (int i = 0; i < numberProjectiles; i++)
            {
                if (i != 0)
                {
                    FiringPoint.Rotate(0, 0, angleIncrease);
                }
                Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            }
            FiringPoint.rotation = originalAngle;

        }
    }
}

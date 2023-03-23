using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretShoot : MonoBehaviour
{
    [SerializeField]
    private Transform FiringPoint1;
    private Transform FiringPointDeviation1;
    [SerializeField]
    private Transform FiringPoint2;
    private Transform FiringPointDeviation2;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float firingspeed = 1f;
    private float lastTimeShot = 0;
    [SerializeField]
    private float shootSpread = 15;
    private Quaternion originalAngle1;
    private Quaternion originalAngle2;
    public ParticleSystem muzzleFlash1;
    public ParticleSystem muzzleFlash2;

    private void Start()
    {
        FiringPointDeviation1 = FiringPoint1;
        FiringPointDeviation2 = FiringPoint2;

    }

    public void SpreadShoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            muzzleFlash1.Play();
            originalAngle1 = FiringPoint1.rotation;
            lastTimeShot = Time.time;
            FiringPoint1.Rotate(0, 0, Random.Range(-shootSpread, shootSpread));
            Instantiate(projectilePrefab, FiringPoint1.position, FiringPoint1.rotation);
            FiringPoint1.rotation = originalAngle1;

            muzzleFlash2.Play();
            originalAngle2 = FiringPoint2.rotation;
            lastTimeShot = Time.time;
            FiringPoint2.Rotate(0, 0, Random.Range(-shootSpread, shootSpread));
            Instantiate(projectilePrefab, FiringPoint2.position, FiringPoint2.rotation);
            FiringPoint2.rotation = originalAngle2;

        }
    }
}

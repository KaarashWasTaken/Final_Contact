using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
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
    private float shootSpread = 15;
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
            muzzleFlash.Play();
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
        }
    }

    public void SpreadShoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            muzzleFlash.Play();
            originalAngle = FiringPoint.rotation;
            lastTimeShot = Time.time;
            FiringPoint.Rotate(0, 0, Random.Range(-shootSpread, shootSpread));
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            FiringPoint.rotation = originalAngle;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    //Shooting & aiming variables
    [SerializeField]
    public float firingspeed = 0.05f;
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    MoveForward projectile;
    //cooldown variables
    [SerializeField]
    public float maxHeat = 25;
    [SerializeField]
    private float coolingEffect = 6f;
    [SerializeField]
    public float heatEffect = 1.2f;
    public float heat;
    private bool onCooldown;
    [SerializeField]
    private float shootSpreadMoving = 12;
    [SerializeField]
    private float shootSpreadStill = 6;
    private float shootSpread = 4;
    private Quaternion originalAngle;
    public ParticleSystem muzzleFlash;
    public float damage;
    void Update()
    {
        //Gets a cooldown so cant shoot if weapon gets too hot
        if (heat > maxHeat)
        {
            onCooldown = true;
        }
        //checks if cooldown is over
        if (heat < 0 && onCooldown)
        {
            onCooldown = false;
        }
        //Changes shootSpread depending on if player is moving
        if (GetComponentInParent<PlayerController>().moving)
        {
            shootSpread = shootSpreadMoving;
        }
        else
        {
            shootSpread = shootSpreadStill;
        }
        //cools the weapon each frame
        if (heat > 0 && lastTimeShot + firingspeed <= Time.time)
            heat -= coolingEffect *Time.deltaTime;
    }
    public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time && !onCooldown)
        {
            muzzleFlash.Play();
            originalAngle = FiringPoint.rotation;
            heat += heatEffect;
            lastTimeShot = Time.time;
            FiringPoint.Rotate(0, 0, Random.Range(-shootSpread, shootSpread));
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            FiringPoint.rotation = originalAngle;
        }
    }
}

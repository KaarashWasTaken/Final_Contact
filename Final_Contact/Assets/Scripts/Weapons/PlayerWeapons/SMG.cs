using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    //Shooting & aiming variables
    [SerializeField]
    public float firingspeed = 0.1f;
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    //cooldown variables
    [SerializeField]
    public float maxHeat = 25;
    [SerializeField]
    private float coolingEffect = 0.5f;
    [SerializeField]
    public float heatEffect = 1;
    public float heat;
    private bool onCooldown;
    [SerializeField]
    private float shootSpread = 15;
    private Quaternion originalAngle;
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
        //cools the weapon each frame
        if (heat > 0 && lastTimeShot + firingspeed <= Time.time)
            heat -= coolingEffect;
    }
    public void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time && !onCooldown)
        {
            originalAngle = FiringPoint.rotation;
            heat += heatEffect;
            lastTimeShot = Time.time;
            FiringPoint.Rotate(0, 0, Random.Range(-shootSpread, shootSpread));
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            FiringPoint.rotation = originalAngle;
        }
    }
}

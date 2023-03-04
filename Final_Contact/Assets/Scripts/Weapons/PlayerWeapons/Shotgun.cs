using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shotgun : MonoBehaviour
{
    //Shooting & aiming variables
    [Header("Shooting")]
    [SerializeField]
    public float firingspeed = 0.5f;
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private int numberProjectiles = 3;
    [SerializeField]
    private float spread = 35;
    private Quaternion originalAngle;
    //cooldown variables
    [Header("Cooldown")]
    [SerializeField]
    public float maxHeat = 25;
    [SerializeField]
    private float coolingEffect = 7f;
    [SerializeField]
    public float heatEffect = 4;
    public float heat;
    private bool onCooldown;

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
            heat -= coolingEffect * Time.deltaTime;
    }

    public void Shoot()
    {
        
        if (lastTimeShot + firingspeed <= Time.time && !onCooldown)
        {
            heat = heat + heatEffect;
            originalAngle = FiringPoint.rotation;
            lastTimeShot = Time.time;

            float startAngle = -(spread / 2f);
            float angleIncrease = spread / (numberProjectiles);
            FiringPoint.Rotate(0, 0, startAngle);
            for (int i = 0; i < numberProjectiles; i++)
            {
                FiringPoint.Rotate(0, 0, angleIncrease);
                //FiringPoint.rotation.Normalize();
                Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            }
            FiringPoint.rotation=originalAngle;

        }
        
    }
}

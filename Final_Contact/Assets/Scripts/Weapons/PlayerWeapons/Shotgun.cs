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
    [SerializeField]
    private Rigidbody projectilePrefab;
    private Quaternion originalAngle;
    private Vector3 deviation;
    //cooldown variables
    [SerializeField]
    public float maxHeat = 25;
    [SerializeField]
    private float coolingEffect = 0.005f;
    [SerializeField]
    public float heatEffect = 1;
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
            heat = heat - coolingEffect;
    }

    public void Shoot()
    {
        
        if (lastTimeShot + firingspeed <= Time.time && !onCooldown)
        {
            heat = heat + heatEffect;
            originalAngle = FiringPoint.rotation;
            //deviation = originalAngle.EulerAngles();
            lastTimeShot = Time.time;
            //Quaternion deviation = FiringPoint.rotation;


            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);

            //FiringPointDeviation.Rotate(FiringPointDeviation.position, -25);
            FiringPoint.Rotate(FiringPoint.position, -spread);
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);

            FiringPoint.Rotate(FiringPoint.position, (2*spread));
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
            
            Debug.Log(FiringPoint.rotation.ToString());
            FiringPoint.rotation=originalAngle;
            Debug.Log(spread.ToString());
        }
        
    }
}

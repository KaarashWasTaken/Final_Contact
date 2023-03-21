using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private float health;
    [Header("bullets")]
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private int numberProjectiles = 20;
    private float spread = 360;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Shoot();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            health -= other.gameObject.GetComponent<MoveForward>().damage;
        }
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            health -= other.gameObject.GetComponent<EnemyMoveForward>().damage;
        }
    }
    public void Shoot()
    {
        float angleIncrease = spread / (numberProjectiles - 1);
        for (int i = 0; i < numberProjectiles; i++)
        {
            FiringPoint.Rotate(0, 0, angleIncrease);
            
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
        }
    }
}

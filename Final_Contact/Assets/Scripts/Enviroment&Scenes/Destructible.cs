using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    private float health;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
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
}

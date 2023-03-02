using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryDummy : MonoBehaviour
{
    [SerializeField]
    private float health;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(transform.parent.gameObject);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            health -= other.gameObject.GetComponent<MoveForward>().damage;
            Destroy(other.gameObject);
        }
    }
}

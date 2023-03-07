using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandard : MonoBehaviour
{
    public float health;
    public Material dissolveMaterial;
    private MaterialPropertyBlock propBlock;
    private Renderer[] _renderer;
    private float dissolveValue = 0.1f;
    private float dissolveSpeed = 0.05f;
    private bool dissolve = false;
    public ParticleSystem deathSpark;
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
        if (!dissolve)
        {
            _renderer = GetComponentsInChildren<Renderer>();
            propBlock = new MaterialPropertyBlock();
            dissolve = true;
            propBlock.SetFloat("_Dissolve_Amount", 0);
        }
        foreach (Renderer g in _renderer)
        {
            g.GetPropertyBlock(propBlock);
            g.material = dissolveMaterial;
            propBlock.SetFloat("_Dissolve_Amount", dissolveValue += Time.deltaTime * dissolveSpeed);
            g.SetPropertyBlock(propBlock);
        }
        Destroy(transform.parent.gameObject, 2.5f);
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

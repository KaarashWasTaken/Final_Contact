using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryDummy : MonoBehaviour
{
    [SerializeField]
    private float health;
    public Material dissolveMaterial;
    private MaterialPropertyBlock propBlock;
    private Renderer _renderer;
    private float dissolveValue = 0.1f;
    private float dissolveSpeed = 0.3f;
    private bool dissolve = false;
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
            _renderer = GetComponent<Renderer>();
            propBlock = new MaterialPropertyBlock();
            dissolve = true;
            propBlock.SetFloat("_Dissolve_Amount", 0);
        }
        _renderer.GetPropertyBlock(propBlock);
        _renderer.material = dissolveMaterial;
        dissolveMaterial.SetFloat("_Dissolve_Amount", dissolveValue += Time.deltaTime * dissolveSpeed);
        _renderer.SetPropertyBlock(propBlock);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDissolve : MonoBehaviour
{
    private MaterialPropertyBlock propBlock;
    private Renderer _renderer;
    [SerializeField]
    private float dissolveValue = 0f;
    [SerializeField]
    private float dissolveSpeed = 1f;
    public bool exploding;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        propBlock.SetFloat("_Dissolve_Amount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (exploding)
        {
            _renderer.GetPropertyBlock(propBlock);
            propBlock.SetFloat("_Dissolve_Amount", dissolveValue += Time.deltaTime * dissolveSpeed);
            _renderer.SetPropertyBlock(propBlock);
        }
    }
}

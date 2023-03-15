using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float destroyAfterSeconds = 5.0f;
    private float timeNow;
    private float startTime;
    private Rigidbody rb;
    public float damage = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
        rb.velocity = transform.up * projectileSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;
        MoveProjectile();
    }
    void MoveProjectile()
    {
        if (startTime < timeNow - destroyAfterSeconds)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("InnerWalls") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}

using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    [SerializeField]
    private float destroyAfterSeconds = 5.0f;
    private float timeNow;
    private float startTime;
    private Rigidbody rb;
    public float damage = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        startTime = Time.time;
        rb.velocity = transform.up * projectileSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        timeNow = Time.time;
        MoveProjectile();
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
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
        if (
            other.gameObject.CompareTag("InnerWalls") ||
            other.gameObject.CompareTag("Enemy")
            
            )
        {
            Destroy(gameObject);

        }
        if (other.gameObject.CompareTag("Player") && timeNow >= startTime + 0.05) // may need balancing to avoid being invulnerable when up close
        {
            other.gameObject.GetComponent<playerBehaviour>().health -= 5;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.CompareTag("PickupHealth")
            )
        {
            Destroy(gameObject);
        }
    }
    }
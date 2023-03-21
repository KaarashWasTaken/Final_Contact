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
    public float damage;
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
        timeNow = Time.time; //Updates the variable timeNow every frame to be the current time
        DestroyProjectileAfterTime(); //Calls the DestroyProjectileAfterTime function every frame
        //The line below rotates the projectile in the looking direction every frame
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }
    void DestroyProjectileAfterTime() //Destroys the projectile after the time given in "destroyAfterSeconds"
    {
        if (startTime < timeNow - destroyAfterSeconds)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //If a projectile collides with an innerwall the projectile will be destroyed
        if (other.gameObject.CompareTag("InnerWalls"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            //If a projectile collides with a player the player will lose 5 health and the projectile will be destroyed
            other.gameObject.GetComponent<playerBehaviour>().health -= damage;
            Destroy(gameObject);
        }
    }
}
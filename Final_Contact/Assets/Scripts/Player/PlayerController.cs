using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float initalPlayerSpeed = 10f;
    private float playerSpeed;
    [SerializeField]
    private float rotationSpeed = 720f;
    private Vector2 movementInput = Vector2.zero;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private Rigidbody projectilePrefab;
    private CharacterController controller;
    //Shooting & aiming variables
    [SerializeField]
    public float firingspeed = 0.5f;
    private float shooting = 0;
    private Vector2 aiming = Vector2.zero;
    private float lastTimeShot = 0;
    //Dodge variables
    [SerializeField]
    private float dodgeCD = 5.0f;
    private float dodgeInput = 0;
    private float lastDodge;
    [SerializeField]
    private float boostIncrease = 30.0f;
    [SerializeField]
    private float boostTime = 0.2f;
    private bool isBoostActivated = false;
    // PLayer Down
    private bool downed = false;
    [SerializeField]
    private Rigidbody Player;
    public SphereCollider ReviveCollider;
    public GameObject ReviveSphere;
    private float reviveTimer = 0;
    private float reviveBaseTime;
    private bool reviving = false;
    [SerializeField]
    private float timeToRevive = 3;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerSpeed = initalPlayerSpeed;
        ReviveCollider= gameObject.GetComponent<SphereCollider>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        shooting = context.ReadValue<float>();
    }
    public void Aiming(InputAction.CallbackContext context)
    {
        aiming = context.ReadValue<Vector2>();
    }
    public void OnDodge(InputAction.CallbackContext context)
    {
        dodgeInput= context.ReadValue<float>();
    }
    void Update()
    {
        if (!downed)
        {
            //Player.isKinematic = false;
            controller.detectCollisions = true;
            ReviveSphere.SetActive(false);
            ReviveCollider.enabled = false; //revive collider inactive if not downed
            Vector3 move = new Vector3(movementInput.x * 10, 0, movementInput.y * 10);
            move.Normalize();
            controller.Move(move * Time.deltaTime * playerSpeed);
            Vector3 tempPos = transform.position;
            if (tempPos.y != 2f)
            {
                tempPos.y = 2f;
                transform.position = tempPos;
            }
            if (move != Vector3.zero && aiming == Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            if (aiming != Vector2.zero)
            {
                aimDirection();
            }
            if (shooting != 0)
            {
                Shoot();
            }
            if (dodgeInput != 0 && Time.time >= lastDodge + dodgeCD)
            {
                lastDodge = Time.time;
                Dodge();
            }
            
        }
        if (downed)
        {
            Player.velocity = Vector3.zero;
        }
        //tracks time in revive circle
        if (reviving == true)
        {
            reviveTimer = Time.time - reviveBaseTime;
        }
        //Debug.Log(reviveTimer);
    }
    private void aimDirection()
    {
        Vector3 aim = new Vector3(aiming.x, 0, aiming.y);
        Quaternion toRotation = Quaternion.LookRotation(aim, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        if (lastTimeShot + firingspeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectilePrefab, FiringPoint.position, FiringPoint.rotation);
        }
    }
    private void Dodge()
    {
        if (!isBoostActivated)
        {
            Debug.Log("Boosting player speed");
            isBoostActivated = true;
            Invoke("EndBoost", boostTime);
        }
        if (isBoostActivated)
        {
            playerSpeed += boostIncrease;
        }
    }
    private void EndBoost()
    {
        isBoostActivated = false;
        playerSpeed = initalPlayerSpeed;
    }

    public void Down()
    {
        if (!downed)
        {
            gameObject.tag = "PlayerDown";
            downed = true;
            controller.detectCollisions= false;
            ReviveSphere.SetActive(true);
            //Player.isKinematic= true;
            ReviveCollider.enabled = true;
            Debug.Log("playerisdown");
            transform.rotation = Quaternion.Euler(90, 0, 0);
            
            
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        //timer Start
        if (other.gameObject.CompareTag("Player"))
        {
            reviveBaseTime = Time.time;
            reviving = true;
            Debug.Log("PlayerisRevivingotherplayer");
            Debug.Log(reviveBaseTime);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        //Timer reset to 0
        if (other.gameObject.CompareTag("Player"))
        {
            reviving = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && reviveTimer > timeToRevive)
        {
            Debug.Log("Player Revived");
            downed = false;
            reviving = false;
            reviveTimer = 0;
            gameObject.tag = "Player";
            gameObject.GetComponent<playerBehaviour>().health = 75;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }


    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Player Revivied");
    //        downed = false;
    //        gameObject.tag = "Player";
    //        gameObject.GetComponent<playerBehaviour>().health = 75;
    //    }
    //}
}
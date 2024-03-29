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
    public bool moving = false;
    private CharacterController controller;
    public bool ready = false;
    private float pauseInput = 0;
    private float lastPause = 0;
    private GameObject spawnPoint;
    //Shooting & aiming variables
    public float shooting = 0;
    public Vector2 aiming = Vector2.zero;
    //Dodge variables
    public float dodgeCD = 3.0f;
    private float dodgeInput = 0;
    private float lastDodge;
    [SerializeField]
    private float boostIncrease = 30.0f;
    [SerializeField]
    private float boostTime = 0.2f;
    private bool isBoostActivated = false;
    private float timeSinceDodge;
    //for hud
    public float dodgeTimePercentage=1;
    // PLayer Down
    public bool downed = false;
    [SerializeField]
    private Rigidbody Player;
    public GameObject ReviveSphere;
    private float dropping = 0;
    public bool gettingUp;
    public bool boosting = false;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerSpeed = initalPlayerSpeed;
        DontDestroyOnLoad(gameObject.transform.parent);
        lastDodge = -3;
        StartPos();
    }
    public void StartPos()
    {
        Debug.Log("Spawnpos set");
        spawnPoint = GameObject.Find("PlayerSpawnPoint");
        controller.enabled = false;
        transform.position = spawnPoint.transform.position;
        controller.enabled = true;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        if (Vector2.zero == movementInput)
        {
            moving = false;
        }
        else
        {
            moving= true;
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        shooting = context.ReadValue<float>();
    }
    public void OnDrop(InputAction.CallbackContext context)
    {
        dropping = context.ReadValue<float>();
    }
    public void Aiming(InputAction.CallbackContext context)
    {
        aiming = context.ReadValue<Vector2>();
    }
    public void OnDodge(InputAction.CallbackContext context)
    {
        dodgeInput= context.ReadValue<float>();
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        pauseInput = context.ReadValue<float>();
    }
    void Update()
    {
        if (!downed && !gettingUp)
        {
            ReviveSphere.SetActive(false);
            controller.detectCollisions = true;
            if(!gameObject.CompareTag("Player"))
                gameObject.tag = "Player";
            //ReviveCollider.enabled = false; //revive collider inactive if not downed
            Vector3 move = new(movementInput.x * 10, 0, movementInput.y * 10);
            move.Normalize();
            controller.Move(move * Time.deltaTime * playerSpeed);
            Vector3 tempPos = transform.position;
            if (tempPos.y != spawnPoint.transform.position.y + 0.8f)
            {
                //Debug.Log("Updatingpos");
                tempPos.y = spawnPoint.transform.position.y + 0.8f;
                transform.position = tempPos;
            }
            if (move != Vector3.zero && aiming == Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            if (aiming != Vector2.zero)
            {
                AimDirection();
            }
            if (shooting != 0)
            {
                Shoot();
            }
            if (dropping != 0)
            {
                Drop();
            }
            if (dodgeInput != 0 && Time.time >= lastDodge + dodgeCD)
            {
                lastDodge = Time.time;
                Dodge();
            }
            if (pauseInput != 0 && Time.time > lastPause + 0.1)
            {
                Pause();
                lastPause = Time.time;
            }
        }
        else if(!downed && gettingUp)
        {
            ReviveSphere.SetActive(false);
            Invoke(nameof(GetUp), 3);
        }
        if (downed)
        {
            //tracks time in revive circle
            Player.velocity = Vector3.zero;
        }
        
        timeSinceDodge = Time.time - lastDodge;
        dodgeTimePercentage = timeSinceDodge / dodgeCD;
        
        if (dodgeTimePercentage > 1)
        {
            dodgeTimePercentage = 1;
            lastDodge= Time.time - dodgeCD;
        }
        

    }
    private void AimDirection()
    {
        Vector3 aim = new Vector3(aiming.x, 0, aiming.y);
        Quaternion toRotation = Quaternion.LookRotation(aim, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        gameObject.GetComponentInChildren<WeaponManager>().Shoot();
    }
    private void Drop()
    {
        gameObject.GetComponentInChildren<WeaponManager>().Drop();
    }
    private void Dodge()
    {
        if (!isBoostActivated)
        {
            isBoostActivated = true;
            Invoke(nameof(EndBoost), boostTime);
        }
        if (isBoostActivated)
        {
            playerSpeed += boostIncrease;
        }
        boosting = true;
    }
    private void EndBoost()
    {
        isBoostActivated = false;
        playerSpeed = initalPlayerSpeed;
        boosting= false;
    }
    private void Pause()
    {
        if (!PauseMenu.paused)
        {
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseMenu>().Pause();
        }
        else
        {
            GameObject.FindWithTag("PauseMenu").GetComponent<PauseMenu>().Continue();
        }
    }
    public void Down()
    {
        if (!downed)
        {
            gameObject.tag = "PlayerDown";
            downed = true;
            controller.detectCollisions= false;
            ReviveSphere.SetActive(true);
            Debug.Log("playerisdown");
            Vector3 tempPos = transform.position;
            if (tempPos.y != spawnPoint.transform.position.y + 0.8f)
            {
                tempPos.y = spawnPoint.transform.position.y + 0.8f;
                transform.position = tempPos;
            }
        }
        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().CheckIfAllDown();
    }
    private void GetUp()
    {
        gettingUp = false;
    }
}
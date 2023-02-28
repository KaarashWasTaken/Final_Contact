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
    
    private CharacterController controller;
    public bool ready = false;
    //Shooting & aiming variables
    
    private float shooting = 0;
    private Vector2 aiming = Vector2.zero;
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

   
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerSpeed = initalPlayerSpeed;
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
        Vector3 move = new(movementInput.x * 10, 0, movementInput.y * 10);
        move.Normalize();
        controller.Move(playerSpeed * Time.deltaTime * move);
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
            AimDirection();
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
    private void AimDirection()
    {
        Vector3 aim = new(aiming.x, 0, aiming.y);
        Quaternion toRotation = Quaternion.LookRotation(aim, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        Debug.Log(gameObject.GetComponentInChildren<WeaponManager>().playerWeapon);
        gameObject.GetComponentInChildren<WeaponManager>().shoot();
    }
    private void Dodge()
    {
        if (!isBoostActivated)
        {
            Debug.Log("Boosting player speed");
            isBoostActivated = true;
            Invoke(nameof(EndBoost), boostTime);
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
}
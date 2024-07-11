using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    

    [SerializeField] private ObjectPool bulletsPool;

    [Header("Shooting Settings")]
    [SerializeField] private ShootBehavior shootBehavior;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform weaponTip;
    
    [SerializeField] private Camera myCamera;

    [Header("Interaction Settings")]
    [SerializeField] private LayerMask interactableFilter;
    [SerializeField] private Transform pickupTip;
    [SerializeField] private Rigidbody playerRigidbody;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private LayerMask layerFilter;


    [Header("Other Modules")]
    [SerializeField] private CommanderModule commanderModule;
    [SerializeField] private HealthModule healthModule;

    private IInteractable selectedInteraction;
    private GameObject carriedBox;
    private Vector3 velocity;
    private const float gravity = -9.81f;
    private Vector3 moveDirection;
    private Vector2 lookDirection;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }   

   
    void Update()
    {
        MovePlayer();
        RotatePlayer();
        JumpPlayer();
        GravityCalculation();
        ShootWeapon();
        Interact();
        ChangeWeapon();
        SendCommand();
        
    }
    private void SendCommand()
    {
        if(Input.GetMouseButtonDown(1))
        {
            commanderModule.CreateCommand();
        }
    }
    private void ChangeWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootBehavior.ChangeWeapon(0);       
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            shootBehavior.ChangeWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shootBehavior.ChangeWeapon(2);
        }
    }
    private void Interact()
    {
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f, interactableFilter))
        {
            if (selectedInteraction == null)
            {
                selectedInteraction = hit.collider.gameObject.GetComponent<IInteractable>();
                selectedInteraction.OnHoverEnter();
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {

                selectedInteraction.Interact(this); 
                
                

            }
        }
        else if(selectedInteraction != null)
        {
            selectedInteraction.OnHoverExit();
            selectedInteraction = null;
        }
        
    }

   

    void ShootWeapon()
    {
    if(Input.GetMouseButtonDown(0))
        {
            shootBehavior.ShootWeapon();
           // PooledObject pooledObj = bulletsPool.RetrievePoolObject();
           // Rigidbody projectileClone = pooledObj.GetRigidbody();
           // projectileClone.position = weaponTip.position;
          //  projectileClone.rotation = weaponTip.rotation;
           /// projectileClone.AddForce(myCamera.transform.forward * projectileSpeed, ForceMode.Impulse);
           // pooledObj.ResetPooledObject(4F);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, controller.radius, layerFilter);
    }

    void GravityCalculation()
    {
        
        if (!IsGrounded())
        {

            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y <= 0)
        {
            velocity.y = -1f;
        }
       

        controller.Move(velocity * Time.deltaTime);
    }

    void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            velocity.y = jumpForce;
        }
    }

    void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        Vector3 moveForward = transform.forward * moveDirection.z;
        Vector3 moveRight = transform.right * moveDirection.x;

        float speedMultiplier = 1;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMultiplier = sprintMultiplier;
        }

        controller.Move((moveForward + moveRight) * Time.deltaTime * speed * speedMultiplier);
    }

    void RotatePlayer()
    {
        lookDirection.x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookDirection.y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;


        lookDirection.y = Mathf.Clamp(lookDirection.y, -85f, 85f);

        myCamera.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);
    }

    public Rigidbody GetPlayerRigidBody()
    {
        return playerRigidbody;
    }
    public Transform GetPickUpLocation()
    {
        return pickupTip;
    }
}

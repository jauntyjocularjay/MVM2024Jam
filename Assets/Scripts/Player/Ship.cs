using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    new Camera camera;
    public PlayerData playerData;
    public InputAction playerMovement;
    // public InputAction playerAiming;
    // public InputAction playerFire;
    Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
    Animator animator;
    public GameObject cursor;

    void Start()
    {
        camera = Camera.main;
        animator = gameObject.GetComponent<Animator>();
        playerData.positionOnMap = gameObject.GetComponent<Transform>().position;
        animator.SetTrigger("idle");
    }
    private void OnEnable()
    {
        playerMovement.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
    }
    void Update()
    {
        ReadMovement();
        ReadCursorPosition();
    }
    void ReadMovement()
    {
        playerData.moveDirection = playerMovement.ReadValue<Vector2>();
        playerData.moveDirection.Normalize();

        // if(playerData.moveDirection.x > 0.0f)
        // {
        //     animator.SetTrigger("bankleft");
        // }
        // else if(playerData.moveDirection.x < 0.0f)
        // {
        //     animator.SetTrigger("bankright");
        // }
        // else
        // {
        //     animator.SetTrigger("idle");
        // }

        playerData.positionOnMap = transform.position;
        camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);

        if(playerData.moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, playerData.moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * playerData.rotationSpeed);
        }
    }
    void ReadCursorPosition()
    {
        Vector2 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = new Vector2(
            cursorPosition.x / Screen.height * 10.0f,
            cursorPosition.y / Screen.height * 10.0f
        );
        cursor.transform.position = cursorPosition + playerData.positionOnMap;
    }
    void ReadThumbstickAngle()
    {
        Vector2 cursorPosition = Mouse.current.position.ReadValue() - screenCenter;
        cursorPosition = cursorPosition.normalized;
        cursorPosition *= playerData.cursorRadius;
        cursor.transform.position = cursorPosition + playerData.positionOnMap;
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(
            transform.position.x + (playerData.moveDirection.x * playerData.moveSpeed),
            transform.position.y + (playerData.moveDirection.y * playerData.moveSpeed)
        );
    }
}

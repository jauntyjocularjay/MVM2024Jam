using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    new Camera camera;
    Vector3 position;
    public PlayerData playerData;
    public InputAction playerMovement;
    public InputAction playerAiming;
    public InputAction playerFire;
    Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
    public GameObject cursor;

    void Start()
    {
        camera = Camera.main;
        playerData.positionOnMap = gameObject.GetComponent<Transform>().position;
        // playerData.rotation = gameObject.GetComponent<Transform>().rotation;
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
        playerData.positionOnMap = transform.position;
        // playerData.rotation = transform.rotation;
        playerData.positionOnMap = gameObject.GetComponent<Transform>().position;
        camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);
    }
    void ReadMovement()
    {
        Vector2 moveDirection = playerMovement.ReadValue<Vector2>();
        // playerData.rotation = playerAiming.ReadValue<Quaternion>();
        moveDirection.Normalize();
        playerData.moveDirection = moveDirection;
        // playerData.rotation.Normalize();
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
        // transform.rotation = playerData.rotation;
    }
}

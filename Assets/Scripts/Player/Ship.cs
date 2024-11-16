using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    new Camera camera;
    Vector3 orientation;
    public PlayerData playerData;
    public InputAction playerMovement;
    public InputAction playerAiming;
    public InputAction playerFire;
    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        camera = Camera.main;
        playerData.position = gameObject.GetComponent<Transform>().position;
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
        playerData.position = transform.position;
        camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);
        ReadLeftStick();
    }
    void ReadLeftStick()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();
        moveDirection.Normalize();
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(
            transform.position.x + (moveDirection.x * playerData.moveSpeed),
            transform.position.y + (moveDirection.y * playerData.moveSpeed)
        );
    }
    void OnSkip()
    {}
}

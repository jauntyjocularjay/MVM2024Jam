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

    void Start()
    {
        camera = Camera.main;
        playerData.position = gameObject.GetComponent<Transform>().position;
        playerData.rotation = gameObject.GetComponent<Transform>().rotation;
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
        playerData.position = transform.position;
        playerData.rotation = transform.rotation;
        camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);
    }
    void ReadMovement()
    {
        Vector2 moveDirection = playerMovement.ReadValue<Vector2>();
        playerData.rotation = playerAiming.ReadValue<Quaternion>();
        moveDirection.Normalize();
        playerData.moveDirection = moveDirection;
        playerData.rotation.Normalize();
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(
            transform.position.x + (playerData.moveDirection.x * playerData.moveSpeed),
            transform.position.y + (playerData.moveDirection.y * playerData.moveSpeed)
        );
        transform.rotation = playerData.rotation;
    }
    void OnSkip()
    {}
}

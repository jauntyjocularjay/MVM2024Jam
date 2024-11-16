using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    new Camera camera;
    Vector3 position;
    public PlayerData playerData;
    public PlayerInput input;

    void Start()
    {
        camera = Camera.main;
        playerData.position = gameObject.GetComponent<Transform>().position;
        input = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {
        playerData.position = transform.position;
        camera.transform.position = new (transform.position.x, transform.position.y, -10.0f);
    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate Updating");
        transform.position = new Vector2(
            transform.position.x + 0.02f,
            transform.position.y + 0.03f
        );
    }
    void OnSkip()
    {}
}

using System;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    Camera camera;
    public PlayerData playerData;

    void Start()
    {
        camera = Camera.main;
        playerData.position = gameObject.GetComponent<Transform>().position;
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
}

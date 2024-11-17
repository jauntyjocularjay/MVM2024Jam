using UnityEngine;

public class StaticLayer : Layer
{
    Vector2 position;
    void Start()
    {
        position = gameObject.GetComponent<Transform>().position;
    }
    void FixedUpdate()
    {
        transform.position = playerData.position;
    }
}

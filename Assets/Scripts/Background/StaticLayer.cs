using UnityEngine;

public class StaticLayer : Layer
{
    Vector2 position;
    void Start()
    {
        position = gameObject.GetComponent<Transform>().position;
    }
    void Update()
    {
        gameObject.GetComponent<Transform>().position = playerData.position;
    }
}

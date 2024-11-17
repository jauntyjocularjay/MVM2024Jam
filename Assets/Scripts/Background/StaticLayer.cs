using UnityEngine;

public class StaticLayer : Layer
{
    void LateUpdate()
    {
        transform.position = playerData.positionOnMap;
    }
}

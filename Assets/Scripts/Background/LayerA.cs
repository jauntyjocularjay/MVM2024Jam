using UnityEngine;

public class LayerA : Layer
{
    public float deltaDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deltaDistance = layerData.deltaDistanceA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = deltaDistance * playerData.position;
    }
}

using UnityEngine;

public class LayerB : Layer
{
    public float deltaDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        deltaDistance = layerData.deltaDistanceB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = deltaDistance * playerData.position;
    }
}

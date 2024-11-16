using UnityEngine;

public class LayerC : Layer
{
    public float deltaDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deltaDistance = layerData.deltaDistanceC;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = deltaDistance * playerData.position;
    }
}

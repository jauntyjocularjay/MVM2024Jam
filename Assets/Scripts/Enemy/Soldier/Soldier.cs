using FractionScale;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public SoldierData data;
    public Sprite sprite;
    public Path path;
    UFractionScale progress = new UFractionScale(0,512);
    new Transform transform;

    public void Start()
    {
        sprite = data.sprite;
        path = GetComponent<Path>();
        transform = GetComponent<Transform>();
    }

    public void Update()
    {
        foreach(Vector3 point in path.waypoints)
        {
            while(transform.position.x != point.x && transform.position.y != point.y)
            {
                // transform.position = ;
            }
        }
    }
}

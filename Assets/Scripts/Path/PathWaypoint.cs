using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Enemy/Waypoint", order = 7)]
public class Waypoint : ScriptableObject
{
    public Vector2 waypoint;
    public Waypoint()
    {
        waypoint = new Vector2(0.0f, 0.0f);
    }

    public Waypoint(Transform transform)
    {
        waypoint = transform.position;
    }
}

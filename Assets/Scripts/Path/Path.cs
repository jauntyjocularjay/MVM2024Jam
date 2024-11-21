using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Waypoint> waypoints;
    new Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

}

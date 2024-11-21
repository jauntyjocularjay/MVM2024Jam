using System.Collections.Generic;
using UnityEngine;

public class RedSoldier : Soldier
{
    // SoldierData data;
    // Sprite sprite;
    // Path path;
    List<Vector3> waypoints;

    // void Start()
    // {
    //     sprite = data.sprite;
    //     path = GetComponent<Path>();
    // }
    new void Start()
    {
        base.Start();
        waypoints = path.waypoints;
    }
    
    void Update()
    {
        foreach(Vector3 point in waypoints)
        {}
    }
}

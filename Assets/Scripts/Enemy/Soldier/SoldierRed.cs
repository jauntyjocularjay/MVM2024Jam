using System;
using System.Collections.Generic;
using UnityEngine;

public class RedSoldier : Soldier
{
    List<Vector3> waypoints;
    UFractionScale progress = new UFractionScale(0,512);
    int p = 0;
    Vector3 increment;

    new void Start()
    {
        base.Start();
        waypoints = path.waypoints;
        p = waypoints.Count;
    }
    
    new void Update()
    {
        base.Update();
    }
    void FixedUpdate() 
    {
        UpdatePosition(p, waypoints[p]);
    }
    void UpdatePosition(int Progress, Vector3 point)
    {
        if(progress.Full())
        {
            p++;
            UpdatePosition(p, waypoints[p]);
        }
        progress.Increment();
    }
}

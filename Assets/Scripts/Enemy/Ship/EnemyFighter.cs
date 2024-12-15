using EZLerps;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyFighter : EnemyShip
{
    new CapsuleCollider2D collider;
    ProjectileData projectileData;
    Pathwinder pathwinder;
    new void Start()
    {
        base.Start();
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.velocity = 3;
        knockback = 2;
        if(pathwinder.path != null) pathwinder.Go();
    }
}

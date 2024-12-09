using UnityEngine;

public class EnemyFighter : EnemyShip
{
    new CapsuleCollider2D collider;
    ProjectileData projectileData;

    new void Start()
    {
        base.Start();
        knockback = 2;
    }
}

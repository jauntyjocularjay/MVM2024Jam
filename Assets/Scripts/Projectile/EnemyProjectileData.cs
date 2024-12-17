using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProjectile", menuName = "Projectile/Enemy", order = 1)]
public class EnemyProjectileData : ProjectileData
{
    void Awake()
    {
        hitsEnemy = false;
    }
}

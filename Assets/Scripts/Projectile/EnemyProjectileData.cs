using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Projectile/Enemy", order = 1)]
public class EnemyProjectileData : ProjectileData
{
    void Awake()
    {
        hitsEnemy = false;
    }
}

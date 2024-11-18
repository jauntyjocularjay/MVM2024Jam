using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Projectile/Player", order = 0)]
public class PlayerProjectileData : ProjectileData
{
    void Awake()
    {
        hitsEnemy = true;
    }
}

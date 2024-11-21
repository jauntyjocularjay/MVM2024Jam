using UnityEngine;

public class ProjectileData : ScriptableObject
{
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;
    public float bulletSpd;
    public float lifeTime;
    public bool hitsEnemy;
}

using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float bulletSpd;
    public int Damage;
    public float lifetime;
    public int maxProjectilesOnScreen;
    public List<GameObject> currentProjectiles;
    
    void Start()
    {
        bulletSpd = 20;
        Damage = 2;
        lifetime = 2;
        maxProjectilesOnScreen = 1;
    }
    public abstract void OnShoot(Transform emitter, bool rapid);

}

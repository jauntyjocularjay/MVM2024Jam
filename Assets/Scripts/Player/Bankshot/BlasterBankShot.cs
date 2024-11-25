using System.Collections.Generic;
using UnityEngine;

public class BankShotBlaster : Weapon
{
    public GameObject projectilePrefab;
    public float bulletSpd;
    public float Damage;
    public float lifetime;
    public int projectilesOnScreen;
    public List<GameObject> currentProjectiles;
    override public void OnShoot(Transform emitter, bool rapid)
    {}
}
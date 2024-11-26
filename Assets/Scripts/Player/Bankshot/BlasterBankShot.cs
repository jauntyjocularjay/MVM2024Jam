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
    public override void OnShoot(Transform emitter, bool rapid)
    // do we want the bank shot to have a rapid fire option? 
    {
        if (currentProjectiles.Count < projectilesOnScreen)
        {
            GameObject currentObject = Instantiate(projectilePrefab, emitter.position, emitter.rotation);
            BankShotProjectile currentBullet = currentObject.GetComponent<BankShotProjectile>();

            currentBullet.CalibrateBullet(bulletSpd, Damage, lifetime, this);

            currentProjectiles.Add(currentObject);
        }
    }
}
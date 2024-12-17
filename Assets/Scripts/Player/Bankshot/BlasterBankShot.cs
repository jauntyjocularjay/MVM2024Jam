using System.Collections.Generic;
using UnityEngine;

public class BankShotBlaster : Weapon
{
    public bool rapid;
    
    void Start()
    {
        rapid = false;
        bulletSpd = 20;
        Damage = 2;
        lifetime = 2;
        maxProjectilesOnScreen = 1;
    }
    public override void OnShoot(Transform emitter, bool rapid)
    // do we want the bank shot to have a rapid fire option? 
    {
        if (currentProjectiles.Count < maxProjectilesOnScreen)
        {
            GameObject currentObject = Instantiate(projectilePrefab, emitter.position, emitter.rotation);
            BankShotProjectile currentBullet = currentObject.GetComponent<BankShotProjectile>();

            currentBullet.CalibrateBullet(bulletSpd, Damage, lifetime, this);

            currentProjectiles.Add(currentObject);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class BankShotBlaster : Weapon
{
    public bool rapid;
    
    void Start()
    {
        rapid = false;
        bulletSpd = 2;
        Damage = 2;
        lifetime = 5;
        projectilesOnScreen = 1;
    }
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
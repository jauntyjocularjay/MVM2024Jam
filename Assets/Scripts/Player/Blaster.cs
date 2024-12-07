using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
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
    {
        Debug.Log($"isInRapidFire before shooting:" + rapid);
        if ( currentProjectiles.Count < maxProjectilesOnScreen )
        {
            GameObject currentObject = Instantiate(projectilePrefab, emitter.position, emitter.rotation);
            PlayerProjectile currentBullet = currentObject.GetComponent<PlayerProjectile>();

            currentBullet.CalibrateBullet(bulletSpd, Damage, lifetime, this);

            currentProjectiles.Add(currentObject);
        }
        else if (rapid)
        {
            Debug.Log("Rapid Firing");
            GameObject currentObject = Instantiate(projectilePrefab, emitter.position, emitter.rotation);
            PlayerProjectile currentBullet = currentObject.GetComponent<PlayerProjectile>();

            currentBullet.CalibrateBullet(bulletSpd, Damage, lifetime, this);

            currentProjectiles.Add(currentObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Blaster : Weapon
{
    public GameObject projectilePrefab;
    public float bulletSpd = 20;
    public float Damage = 4;
    public float lifetime = 3;
    public int projectilesOnScreen = 2;
    public List<GameObject> currentProjectiles;

    public override void OnShoot(Transform emitter, bool rapid)
    {
        Debug.Log($"isInRapidFire before shooting:" + rapid);
        if ( currentProjectiles.Count < projectilesOnScreen )
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

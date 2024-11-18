using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Blaster : Weapon
{
    public GameObject projectilePrefab;

    public float bulletSpd;
    public float Damage;
    public float lifetime;

    public int projectilesOnScreen;
    public List<GameObject> currentProjectiles;

    public override void OnShoot(Transform emitter)
    {
        if (currentProjectiles.Count < projectilesOnScreen)
        {

            GameObject currentObject = Instantiate(projectilePrefab, emitter.position, emitter.rotation);
            PlayerProjectile currentBullet = currentObject.GetComponent<PlayerProjectile>();

            currentBullet.CalibrateBullet(bulletSpd, Damage, lifetime, this);

            currentProjectiles.Add(currentObject);



        }
    }
}

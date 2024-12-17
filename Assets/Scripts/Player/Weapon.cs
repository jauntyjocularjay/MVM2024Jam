using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float bulletSpd = 20;
    public int Damage = 4;
    public float lifetime = 3;

    public int maxProjectilesOnScreen = 2;

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

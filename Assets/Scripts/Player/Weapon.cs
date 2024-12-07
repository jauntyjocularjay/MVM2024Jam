using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float bulletSpd = 20;
    public int Damage = 4;
    public float lifetime = 3;

    public int projectilesOnScreen = 2;

    public List<GameObject> currentProjectiles;

    public abstract void OnShoot(Transform emitter, bool rapid);

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class WeaponsHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Weapon primaryWeapon;
    [SerializeField] private Weapon tractorBeamW;
    [SerializeField] private Transform TBp;

    [SerializeField] Transform shotEmitter;

    public float ROF = 0.2f;
    public float TractorROF = 5;

    float ROFCooldown = 0f;
    float tractorCooldown = 0f;

    bool canShoot = true;
    bool canTractor = true;
    bool isInRapidFire = false;

    public void changeRapidFirePower(bool state)
    {
        isInRapidFire = state;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ShootMain()
    {
        if (canShoot == true)
        {

            primaryWeapon.OnShoot(shotEmitter, isInRapidFire);
            ROFCooldown = 0f;
            canShoot = false;
        }
    }

    public void ShootTractor()
    {
        if (canTractor == true)
        {
            tractorBeamW.OnShoot(TBp, isInRapidFire);
            tractorCooldown = 0f;
            canTractor = false;
            if (!isInRapidFire)
            {
                canShoot = false;
            }
        }
    }

    /*void handleWeapons()
    {
        if (Mouse.current.leftButton.isPressed && canShoot == true)
        {
            primaryWeapon.OnShoot(shotEmitter);
            ROFCooldown = 0f;
            canShoot = false;
        }
        if (Mouse.current.rightButton.isPressed && canTractor == true)
        {
            Debug.Log("WEWOWEWOWEWO");
            tractorCooldown = 0f;
            canTractor = false;
            canShoot = false;
        }
    }*/

    void handleCooldowns()
    {
        if (canShoot == false && canTractor == true)
        {
            ROFCooldown += Time.deltaTime;
            if (ROFCooldown >= ROF)
            {
                canShoot = true;
            }
        } else if (canShoot == false && canTractor == false && !isInRapidFire)
        {
            tractorCooldown += Time.deltaTime;
            if (tractorCooldown >= TractorROF)
            {
                canShoot = true;
                canTractor = true;
            }
        } else if (canShoot == false && canTractor == false && isInRapidFire)
        {
            ROFCooldown += Time.deltaTime;
            if (ROFCooldown >= ROF)
            {
                canShoot = true;
            }

            tractorCooldown += Time.deltaTime;
            if (tractorCooldown >= TractorROF)
            {
                canTractor = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //handleWeapons();
        handleCooldowns();
    }
}

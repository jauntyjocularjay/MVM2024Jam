using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class WeaponsHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    private Weapon primaryWeapon;
    private Weapon tractorBeamW;
    private Transform weaponOrigin;

    public float fireRate = 0.2f;
    public float tractorBeamFireRate = 5;

    float primaryWeaponCooldown = 0f;
    float tractorBeamCooldown = 0f;

    bool primaryWeaponEnabled = true;
    bool tractorBeamEnabled = true;
    bool isInRapidFire = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        primaryWeapon = GetComponent<Blaster>();
        tractorBeamW = GetComponent<TractorBeam>();
        weaponOrigin = GetComponentInParent<Transform>();
    }
    public void changeRapidFirePower(bool state)
    {
        isInRapidFire = state;
    }


    public void ShootMain()
    {
        if (primaryWeaponEnabled
 == true)
        {

            primaryWeapon.OnShoot(weaponOrigin, isInRapidFire);
            primaryWeaponCooldown = 0f;
            primaryWeaponEnabled
     = false;
        }
    }

    public void ShootTractor()
    {
        if (tractorBeamEnabled == true)
        {
            tractorBeamW.OnShoot(weaponOrigin, isInRapidFire);
            tractorBeamCooldown = 0f;
            tractorBeamEnabled = false;
            if (!isInRapidFire)
            {
                primaryWeaponEnabled
         = false;
            }
        }
    }

    /*void handleWeapons()
    {
        if (Mouse.current.leftButton.isPressed && primaryWeaponEnabled
 == true)
        {
            primaryWeapon.OnShoot(shotEmitter);
            ROFCooldown = 0f;
            primaryWeaponEnabled
     = false;
        }
        if (Mouse.current.rightButton.isPressed && canTractor == true)
        {
            Debug.Log("WEWOWEWOWEWO");
            tractorCooldown = 0f;
            canTractor = false;
            primaryWeaponEnabled
     = false;
        }
    }*/

    void handleCooldowns()
    {
        if (primaryWeaponEnabled
 == false && tractorBeamEnabled == true)
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled
         = true;
            }
        } else if (primaryWeaponEnabled
 == false && tractorBeamEnabled == false && !isInRapidFire)
        {
            tractorBeamCooldown += Time.deltaTime;
            if (tractorBeamCooldown >= tractorBeamFireRate)
            {
                primaryWeaponEnabled
         = true;
                tractorBeamEnabled = true;
            }
        } else if (primaryWeaponEnabled
 == false && tractorBeamEnabled == false && isInRapidFire)
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled
         = true;
            }

            tractorBeamCooldown += Time.deltaTime;
            if (tractorBeamCooldown >= tractorBeamFireRate)
            {
                tractorBeamEnabled = true;
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

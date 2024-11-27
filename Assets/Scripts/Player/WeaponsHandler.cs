using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WeaponsHandler : MonoBehaviour, IDataPersistence
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private int weaponsIndex;
    private Weapon primaryWeapon;
    private Weapon tractorBeamW;
    private Transform weaponOrigin;
    private tractorBeamProjectile tractorBeamObject;
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
        tractorBeamObject = GetComponentInChildren<tractorBeamProjectile>();
        weaponsIndex = 0;
        primaryWeapon = weapons[weaponsIndex];
        tractorBeamW = GetComponent<TractorBeam>();
        weaponOrigin = GetComponentInParent<Transform>();
    }
    void Update()
    {
        //handleWeapons();
        handleCooldowns();
    }
    public void IncrementWeaponSelector(bool positive)
    {
        if(positive && weaponsIndex + 1 < weapons.Count)
        {
            weaponsIndex++;
            primaryWeapon = weapons[weaponsIndex];
        }
        else if(!positive && weaponsIndex -1 < weapons.Count)
        {
            weaponsIndex--;
            primaryWeapon = weapons[weaponsIndex];
        }
        else
        {
            weaponsIndex = 0;
            primaryWeapon = weapons[weaponsIndex];
        }
    }
    public void changeRapidFirePower(bool state)
    {
        isInRapidFire = state;
    }
    public void ShootMain()
    {
        if (primaryWeaponEnabled)
        {

            primaryWeapon.OnShoot(weaponOrigin, isInRapidFire);
            primaryWeaponCooldown = 0f;
            primaryWeaponEnabled = false;
        }
    }
    public void ShootBankShot()
    {
        Debug.Log("Bank shot: boing, boing!");
        if(primaryWeaponEnabled)
        {
            primaryWeapon.OnShoot(weaponOrigin, false);
            primaryWeaponCooldown = 0.0f;
            primaryWeaponEnabled = false;
        }
    }
    public void ShootTractor()
    {
        if (tractorBeamEnabled)
        {
            tractorBeamW.OnShoot(tractorBeamObject.gameObject.transform, isInRapidFire);
            tractorBeamCooldown = 0f;
            tractorBeamEnabled = false;
            if (!isInRapidFire)
            {
                primaryWeaponEnabled = false;
            }
        }
    }
    void handleCooldowns()
    {
        if (
            !primaryWeaponEnabled && 
            tractorBeamEnabled
        )
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled = true;
            }
        }
        else if (
            !primaryWeaponEnabled && 
            tractorBeamEnabled && 
            !isInRapidFire
        )
        {
            tractorBeamCooldown += Time.deltaTime;
            if (tractorBeamCooldown >= tractorBeamFireRate)
            {
                primaryWeaponEnabled = true;
                tractorBeamEnabled = true;
            }
        } else if (
            !primaryWeaponEnabled && 
            !tractorBeamEnabled && 
            isInRapidFire
        )
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled = true;
            }

            tractorBeamCooldown += Time.deltaTime;
            if (tractorBeamCooldown >= tractorBeamFireRate)
            {
                tractorBeamEnabled = true;
            }
        }
    }
    /*void handleWeapons()
    {
        if (
            Mouse.current.leftButton.isPressed && 
            primaryWeaponEnabled
        )
        {
            primaryWeapon.OnShoot(shotEmitter);
            ROFCooldown = 0f;
            primaryWeaponEnabled = false;
        }
        if (Mouse.current.rightButton.isPressed && canTractor)
        {
            Debug.Log("WEWOWEWOWEWO");
            tractorCooldown = 0f;
            canTractor = false;
            primaryWeaponEnabled = false;
        }
    }*/
}

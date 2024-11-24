using System.Collections.Generic;
using UnityEngine;


public class WeaponsHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    private Weapon primaryWeapon;
    private Weapon tractorBeamW;
    private Transform weaponOrigin;
    private TractorBeamProjectile tractorBeamObject;
    public float fireRate = 0.2f;
    public float tractorBeamFireRate = 5;
    float primaryWeaponCooldown = 0f;
    float tractorBeamCooldown = 0f;
    bool primaryWeaponEnabled = true;
    bool tractorBeamEnabled = true;
    bool isInRapidFire = false;
    void Start()
    {
        tractorBeamObject = GetComponentInChildren<TractorBeamProjectile>();
        primaryWeapon = GetComponent<Blaster>();
        tractorBeamW = GetComponent<TractorBeam>();
        weaponOrigin = GetComponentInParent<Transform>();
    }
    void Update()
    {
        //handleWeapons();
        HandleCooldowns();
    }
    public void ChangeRapidFirePower(bool state)
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
    void HandleCooldowns()
    {
        if (
            tractorBeamEnabled &&
            !primaryWeaponEnabled
        )
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled = true;
            }
        } else if (
            !primaryWeaponEnabled && 
            !tractorBeamEnabled && 
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

}

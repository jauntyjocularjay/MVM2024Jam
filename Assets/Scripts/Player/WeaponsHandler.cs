using System.Collections.Generic;
using UnityEngine;

public class WeaponsHandler : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
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
        primaryWeapon = GetComponent<Blaster>();
        tractorBeamW = GetComponent<TractorBeam>();
        weaponOrigin = GetComponentInParent<Transform>();
    }
    void Update()
    {
        //handleWeapons();
        handleCooldowns();
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
    public void ShootTractor()
    {
        if (tractorBeamEnabled)
        {
            tractorBeamW.OnShoot(tractorBeamObject.gameObject.transform, isInRapidFire);
            tractorBeamCooldown = 0f;
            tractorBeamEnabled = false;
            if (!isInRapidFire)
            /*
            The rapid fire applies to the weapons handler itself currently.  The reason why this is a factor is that while the tractor beam is active and on cooldown, you cannot shoot the primary weapon.
            Otherwise you would be able to use the blaster in rapid fire while the tractor beam is in cooldown
            @todo This block should be unecessary. We should separate the tractor beam and the blasters.
            */
            {
                primaryWeaponEnabled = false;
            }
        }
    }
    void handleCooldowns()
    {
        if (
            primaryWeaponEnabled && 
            tractorBeamEnabled
        )
        {
            primaryWeaponCooldown += Time.deltaTime;
            if (primaryWeaponCooldown >= fireRate)
            {
                primaryWeaponEnabled = true;
            }
        } else if (
            primaryWeaponEnabled && 
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
            primaryWeaponEnabled && 
            tractorBeamEnabled &&
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
        if (Mouse.current.leftButton.isPressed && primaryWeaponEnabled)
        {
            primaryWeapon.OnShoot(shotEmitter);
            ROFCooldown = 0f;
            primaryWeaponEnabled
     = false;
        }
        if (Mouse.current.rightButton.isPressed && canTractor)
        {
            Debug.Log("WEWOWEWOWEWO");
            tractorCooldown = 0f;
            canTractor = false;
            primaryWeaponEnabled
     = false;
        }
    }*/
}

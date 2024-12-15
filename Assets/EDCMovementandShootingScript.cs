using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EDCMovementandShootingScript : MonoBehaviour
{
    public Transform shotPos;

    public GameObject ShieldObj;
    public List<GameObject> Shields;

    public List<Transform> ShieldLocs;

    public GameObject projectile;

    public GameObject GrenadeProjectile;
    public float grenadeLifeTime;
    public float grenadeDragTime;

    public int grenadeClusterAmmount;

    [SerializeField] float ProjectileCooldown;
    float currentProjCooldown;

    [SerializeField] float GrenadeCooldown;
    float currentGrenadeCooldown;

    [SerializeField] float ShieldRefreshCooldown;
    float currentShieldCooldown;


    void RefreshShields()
    {
        if (Shields.Count < ShieldLocs.Count)
        {
            for (int i = 0; i < Shields.Count; i++)
            {
                Destroy(Shields[i]);
            }
        }

        Shields.Clear();
        currentShieldCooldown = ShieldRefreshCooldown;
        SpawnShields();

    }

    void SpawnShields()
    {
        for(int i = 0; i < ShieldLocs.Count; i++)
        {
            Instantiate(ShieldObj, ShieldLocs[i].position, ShieldLocs[i].rotation);
        }
    }

    void shootProjectile()
    {
        GameObject currentObject = Instantiate(projectile, shotPos.position, shotPos.rotation);
        EDCProjectile currentBullet = currentObject.GetComponent<EDCProjectile>();

        currentBullet.CalibrateBullet(10f, 25, 5);

        currentProjCooldown = ProjectileCooldown;

    }

    void shootGrenade()
    {
        for (int i = 0; i < grenadeClusterAmmount; i++)
        {
            GameObject newNade = Instantiate(GrenadeProjectile, shotPos.position, shotPos.rotation);
            newNade.transform.rotation = Quaternion.Euler(0f, 0f, (transform.rotation.eulerAngles.z + UnityEngine.Random.Range(-25f, 25f)));

            newNade.GetComponent<grenade>().CalibrateBullet(10, 7, 0.1f);

           
        }

        currentGrenadeCooldown = GrenadeCooldown;
    }

    public void InitializeFight()
    {
        SpawnShields();
        currentGrenadeCooldown = GrenadeCooldown;
        currentProjCooldown = ProjectileCooldown;
        currentShieldCooldown = ShieldRefreshCooldown;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeFight();
    }

    void eventClock()
    {
        currentShieldCooldown -= Time.deltaTime;
        currentProjCooldown -= Time.deltaTime;
        currentGrenadeCooldown -= Time.deltaTime;
    }

    void handleCooldowns()
    {
        if(currentShieldCooldown <= 0.0f)
        {
            RefreshShields();
        }
        if (currentProjCooldown <= 0.0f)
        {
            shootProjectile();
        }
        if (currentGrenadeCooldown <= 0.0f)
        {
            shootGrenade();
        }

        //TODO, add rest of cooldowns;
    }

    // Update is called once per frame
    void Update()
    {
        eventClock();
        handleCooldowns();
    }
}

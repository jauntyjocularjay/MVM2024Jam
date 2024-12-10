using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EDCMovementandShootingScript : MonoBehaviour
{
    public GameObject ShieldObj;
    public List<GameObject> Shields;

    public List<Transform> ShieldLocs;

    public GameObject projectile;

    public GameObject GrenadeProjectile;

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
        //TODO, add rest of cooldowns;
    }

    void handleCooldowns()
    {
        if(currentShieldCooldown <= 0.0f)
        {
            RefreshShields();
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

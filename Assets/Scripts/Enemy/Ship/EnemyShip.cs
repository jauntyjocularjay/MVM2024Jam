using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public int knockback;
    public List<VFX> sparks;
    private EnemyHealth enemyHealth;
    private VFX vfx;
    public Pathwinder pathwinder;
    private HelperShip helperShip;
    void Start()
    {
        vfx = GetComponent<VFX>();
        enemyHealth = GetComponent<EnemyHealth>();
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.Go();
    }
    void Update()
    {
        if(enemyHealth.GetHP() <= 3.0f)
        {
            sparks[0].Play();
        }
        
        if(enemyHealth.GetHP() <= 2.0f)
        {
            sparks[1].Play();
        }
    }
    bool DiesOnContact()
    {
        if(knockback <= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

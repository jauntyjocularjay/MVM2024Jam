using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float knockback;
    public List<VFX> sparks;
    private EnemyHealth enemyHealth;
    private VFX vfx;
    void Start()
    {
        vfx = GetComponent<VFX>();
        enemyHealth = GetComponent<EnemyHealth>();
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
        if(knockback <= 2.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public abstract class EnemyShip : MonoBehaviour
{
    public float knockback;
    private new Transform transform;
    private List<VFX> sparks;
    private EnemyHealth enemyHealth;
    private VFX vfx;
    private HelperShip helperShip;
    public EnemyData enemyData;
    public GameManager gameManager;
    public void Start()
    {
        transform = GetComponent<Transform>();
        enemyData = ScriptableObject.Instantiate<EnemyData>(enemyData);
        vfx = GetComponent<VFX>();
        enemyHealth = GetComponent<EnemyHealth>();

        gameManager.enemyData.Add(enemyData);

    }
    public void Update()
    {
        enemyData.position = transform.position;
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
        if(knockback <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

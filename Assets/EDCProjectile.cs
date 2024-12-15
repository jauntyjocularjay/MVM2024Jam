using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EDCProjectile : MonoBehaviour
{
    private float bulletSpd;
    private int Damage;
    private float lifeTime;
    [SerializeField] Rigidbody2D rb;


    public void CalibrateBullet(float Speed, int bDamage, float life)
    {
        bulletSpd = Speed;
        Damage = bDamage;
        lifeTime = life;

        rb.linearVelocity = transform.up * bulletSpd;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(Damage);
            DestroyProjectile();
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShip>().TakeDamage();
            DestroyProjectile();
        }
        if(collision.gameObject.tag == "Shield")
        {
            if (!collision.gameObject.GetComponent<EDCShield>().playerOwned)
            {
                DestroyProjectile();
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180f);
                rb.linearVelocity = transform.up * bulletSpd;
            }
        }
        if (collision.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

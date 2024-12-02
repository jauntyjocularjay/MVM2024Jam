using System.Collections.Generic;
using UnityEngine;

public class BankShotProjectile : MonoBehaviour
{
    private float bulletSpd;
    private int Damage;
    private float lifeTime;
    BankShotBlaster parentBlaster;
    [SerializeField] Rigidbody2D rb;

    public void CalibrateBullet(float Speed, int bDamage, float life, BankShotBlaster blaster)
    {
        bulletSpd = Speed;
        Damage = bDamage;
        lifeTime = life;
        parentBlaster = blaster;

        rb.linearVelocity = transform.up * bulletSpd;
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Enemy")
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(Damage);
            DestroyProjectile();
        }
        if (collision.gameObject.tag.Equals("Wall"))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        parentBlaster.currentProjectiles.Remove(gameObject);
        Destroy(gameObject);
    }
}
using UnityEngine;

public class playerProjectile : MonoBehaviour
{


    private float bulletSpd;
    private float Damage;
    private float lifeTime;
    Blaster parentBlaster;
    [SerializeField] Rigidbody2D rb;

    public void CalibrateBullet(float Speed, float bDamage, float life, Blaster pB)
    {
        bulletSpd = Speed;
        Damage = bDamage;
        lifeTime = life;
        parentBlaster = pB;

        rb.linearVelocity = transform.up * bulletSpd;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            destroyProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyHealth>().takeDamage(Damage);
            destroyProjectile();
        }
        if (collision.gameObject.tag == "Wall")
        {
            destroyProjectile();
        }
    }

    private void destroyProjectile()
    {
        parentBlaster.currentProjectiles.Remove(gameObject);
        Destroy(gameObject);
    }
}
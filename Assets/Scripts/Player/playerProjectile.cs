using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private float bulletSpd;
    private int Damage;
    private float lifeTime;
    Blaster parentBlaster;
    [SerializeField] Rigidbody2D rb;

    public void CalibrateBullet(float Speed, int bDamage, float life, Blaster pB)
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
            DestroyProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shield")
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(Damage);
            DestroyProjectile();
        }
        if (collision.gameObject.tag == "Wall")
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

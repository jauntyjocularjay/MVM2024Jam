using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private float bulletSpd;
    public float Damage;
    private float lifeTime;
    Blaster parentBlaster;
    [SerializeField] Rigidbody2D rb;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            DestroyProjectile();
        }
    }
    public void CalibrateBullet(float Speed, float bDamage, float life, Blaster pB)
    {
        bulletSpd = Speed;
        Damage = bDamage;
        lifeTime = life;
        parentBlaster = pB;

        rb.linearVelocity = transform.up * bulletSpd;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyHealth>().takeDamage(Damage);
            DestroyProjectile();
        }
        if (collision.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
    }
    public void DestroyProjectile()
    {
        parentBlaster.currentProjectiles.Remove(gameObject);
        Destroy(gameObject);
    }
}

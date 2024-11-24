using UnityEngine;

public class BankShotProjectile : PlayerProjectile
{
    new public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyHealth>().takeDamage(Damage);
            DestroyProjectile();
        }
        if (collision.gameObject.tag == "Wall")
        {
            Ricochet(collision.gameObject.GetComponent<Transform>());
        }
    }
    private void Ricochet(Transform target)
    // Ricochet inverts the trajectory of the projectile in response to being banked off of a barrier.
    {
        float targetAngle = target.rotation.eulerAngles.z;
    }
}

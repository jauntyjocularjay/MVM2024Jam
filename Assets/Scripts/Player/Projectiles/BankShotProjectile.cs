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
            Richochet(collision.gameObject.GetComponent<Transform>());
        }
    }

    private void Richochet(Transform target)
    {
        float targetAngle = target.rotation.eulerAngles.z;
        
    }
}

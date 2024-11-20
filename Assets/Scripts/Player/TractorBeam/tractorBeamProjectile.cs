using UnityEngine;

public class tractorBeamProjectile : MonoBehaviour
{
    private float bulletSpd;
    public float lifeTime;
    tractorBeam parentBlaster;
    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            destroyProjectile();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealth hitEnemy = collision.gameObject.GetComponent<enemyHealth>();
            PlayerShip player = FindFirstObjectByType<PlayerShip>();

            if(hitEnemy.canBeCaptured)
            {
                if(hitEnemy.checkCapture())
                {
                    if(player.helperShips.Count < player.maxHelperShips)
                    {
                        player.addHelperShip(hitEnemy);
                    }
                }
            }

            destroyProjectile();
        }
    }

    private void destroyProjectile()
    {
        gameObject.SetActive(false);
    }

}

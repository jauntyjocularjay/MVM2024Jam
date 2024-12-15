using UnityEngine;

public class grenade : MonoBehaviour
{
    public float bulletSpd;
    public float lifeTime;
    public float dragTime;
    float remainingLifeTime;

    [SerializeField] Rigidbody2D rb;

    public GameObject explosionEffect;

    private void Awake()
    {
        remainingLifeTime = lifeTime;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void CalibrateBullet(float Speed, float life, float drag)
    {
        bulletSpd = Speed;
        lifeTime = life;
        dragTime = drag;

        remainingLifeTime = lifeTime;

        rb.linearVelocity = transform.up * bulletSpd;
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        remainingLifeTime -= Time.deltaTime;

        if(remainingLifeTime <= (lifeTime - dragTime))
        {
            Debug.Log("Object should freeze!");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(remainingLifeTime <= 0f)
        {
            Explode();
        }
    }
}

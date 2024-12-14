using UnityEngine;

public class grenade : MonoBehaviour
{

    public float lifeTime;
    public float dragTime;
    float remainingLifeTime;

    public GameObject explosionEffect;

    private void Awake()
    {
        remainingLifeTime = lifeTime;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        if(remainingLifeTime <= 0f)
        {
            Explode();
        }
    }
}

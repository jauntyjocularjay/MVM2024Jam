using UnityEngine;

public class tractorBeamProjectile : MonoBehaviour
{
    private float bulletSpd;
    public float maxLifeTime;
    float lifeTime;
    TractorBeam parentBlaster;
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

    public void refillLife()
    {
        lifeTime = maxLifeTime;
    }



    private void destroyProjectile()
    {
        gameObject.SetActive(false);
    }

}

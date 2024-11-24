using UnityEngine;

public class TractorBeamProjectile : MonoBehaviour
{
    private float bulletSpd;
    public float maxLifeTime;
    float lifeTime;
    TractorBeam parentBlaster;
    [SerializeField] Rigidbody2D rb;

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

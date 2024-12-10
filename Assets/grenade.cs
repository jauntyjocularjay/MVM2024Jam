using UnityEngine;

public class grenade : MonoBehaviour
{

    public float lifeTime;
    float remainingLifeTime;

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

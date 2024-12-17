using UnityEngine;

public class explosion : MonoBehaviour
{
    public float lifetime = 1f;
    float lifeTimeLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTimeLeft = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeLeft -= Time.deltaTime;

        if(lifeTimeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class corpseScript : MonoBehaviour
{
    public float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        { Destroy(gameObject); }
    }
}

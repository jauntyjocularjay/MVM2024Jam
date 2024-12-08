using UnityEngine;

public class Formation : MonoBehaviour
{
    new CircleCollider2D collider;
    EZLerp lerp;
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        lerp = GetComponent<EZLerp>();
    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals(Tags.Player))
        {}
        else if(collision.collider.tag.Equals(Tags.Wall))
        {}
    }
}


using UnityEngine;

public class Solid : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    new BoxCollider2D collider;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider.size = spriteRenderer.size;
    }


}

using UnityEngine;

public class Block : MonoBehaviour
{
    new SpriteRenderer renderer;
    new BoxCollider2D collider;
    public bool isSkippable = false;
    public bool deathOnContact = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        collider.size = renderer.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

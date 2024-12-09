using UnityEngine;

public class ParabolicShield : MonoBehaviour
{
    new BoxCollider2D collider;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.offset = new Vector2(0, 0.38f);
        collider.size = new Vector2(1.0f, 0.12f);
    }
    void Update()
    {
        
    }
}

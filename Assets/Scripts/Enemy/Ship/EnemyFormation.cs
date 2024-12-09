using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    new CapsuleCollider2D collider;
    Vector2 pointOfContact;
    EZLerp lerp;
    public float lerpSegmentLength;
    public float lerpSegmentDuration;
    float angleOfPlayer;
    float angleOfWall;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        lerp = GetComponent<EZLerp>();
    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        pointOfContact = collision.GetContact(0).normal;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        // float angleOfContact = pointOfContact;
        if(collider.gameObject.CompareTag(Tags.Player))
        {
            Debug.Log("Collided with player");
        }
        else if(collider.gameObject.CompareTag(Tags.Wall))
        {
            Debug.Log("Collided with wall");

        }
    }
}

using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float lerpSegmentLength;
    public float lerpSegmentDuration;
    float angleOfPlayer;
    float angleOfWall;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    
    void OnCollisionEnter2d(Collision2D collision)
    {
        Vector2 pointOfContact = collision.GetContact(0);
        if(collision.collider.tag == Tags.Player)
        {
            
        }
        else if(collision.collider.tag = Tags.Wall)
        {

        }
    }
}

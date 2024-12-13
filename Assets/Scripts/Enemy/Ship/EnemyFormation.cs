
using System;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    new CapsuleCollider2D collider;
    new Transform transform;
    Vector3 pointOfContact;
    Vector3 directionOfPlayer;
    EZLerp lerp;
    float angleOfWall;
    float distanceToMaintain;
    float distanceFromWallToMaintain;
    public PlayerData playerData;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        transform = GetComponent<Transform>();
        lerp = GetComponent<EZLerp>();
        distanceToMaintain = 4.0f;
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        Debug.Log($"Vector from Player to Formation: {VectorFromPlayer()}");
        MoveAwayFromPlayer();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        pointOfContact = collision.GetContact(0).normal;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag(Tags.Wall))
        {
            Debug.Log("Collided with wall");
        }
    }
    Vector3 VectorFromPlayer()
     // The distance between player's and enemy's position
     // @todo fix this because you did it wrong.
    {
        return new Vector3(
            transform.position.x - playerData.positionOnMap.x,
            transform.position.y - playerData.positionOnMap.y
        );
    }
    void MoveAwayFromPlayer()
    {
        Vector3 distanceFromPlayer = VectorFromPlayer();
        Vector3 angleOfApproach = VectorFromPlayer().normalized;
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y);
        // if approaching from the east/west && too close
        if(distanceFromPlayer.x >= 0 && TooClose(distanceFromPlayer.x)) // east
        {
            endPosition.x = playerData.positionOnMap.x + distanceToMaintain;
        }
        else if (distanceFromPlayer.x < 0 && TooClose(distanceFromPlayer.x)) // west
        {
            endPosition.x = playerData.positionOnMap.x - distanceToMaintain;
        }

        // if approaching from the north/south && too close
        if(distanceFromPlayer.y >= 0 && TooClose(distanceFromPlayer.y))
        {
            endPosition.y = playerData.positionOnMap.y + distanceToMaintain;
        }
        else if(distanceFromPlayer.y < 0 && TooClose(distanceFromPlayer.y))
        {
            endPosition.y = playerData.positionOnMap.y - distanceToMaintain;
        }

        if(TooClose(distanceFromPlayer.x) || TooClose(distanceFromPlayer.y))
        {
            lerp.Setup(endPosition, 0.5f);
        }
    }

    bool TooClose(float distanceFromPlayer)
    {
        return distanceFromPlayer < distanceToMaintain;
    }
}

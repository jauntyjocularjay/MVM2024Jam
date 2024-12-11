using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFormation : MonoBehaviour
{
    new CapsuleCollider2D collider;
    new Transform transform;
    Vector3 pointOfContact;
    Vector3 directionOfPlayer;
    EZLerp lerp;
    public float lerpSegmentLength;
    public float lerpSegmentDuration;
    float angleOfWall;
    float distanceFromPlayerToMaintain;
    float distanceFromWallToMaintain;
    public PlayerData playerData;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        transform = GetComponent<Transform>();
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
            MoveAwayFromPlayer(VectorFromPlayer().magnitude, VectorFromPlayer().normalized);
        }
        else if(collider.gameObject.CompareTag(Tags.Wall))
        {
            Debug.Log("Collided with wall");

        }
    }

    Vector3 VectorFromPlayer()
     // The distance between player's and enemy's position
    {
        /*
        player position: (-1,-1)
        enemy Formation: (12, 12) (ThisFile)
        */
        Vector3 currentPosition = new Vector3
        (
            Mathf.Abs(transform.position.x),
            Mathf.Abs(transform.position.y)
        );
        Vector3 pointOfContact = new Vector3
        (
            Mathf.Abs(playerData.positionOnMap.x),
            Mathf.Abs(playerData.positionOnMap.y)
        );
        return new Vector3
        (
            // if playerPosition <= currentPosition, the point of contact is below the formation
            currentPosition.x + pointOfContact.x,
            currentPosition.y + pointOfContact.y
        );
    }
    void MoveAwayFromPlayer(float vectorFromPlayer, Vector3 angleFromPlayer)
    {
        Vector3 endPosition = new Vector3
        (
            vectorFromPlayer * angleFromPlayer.x,
            vectorFromPlayer * angleFromPlayer.y
        );
        lerp.Lerp(endPosition, Stats.EnemyVelocity * vectorFromPlayer); // .lerpDuration = Stats.EnemyVelocity * vectorFromPlayer;
        // lerp.condition = true;
    }
}

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
     // The difference between player's and enemy's position
    {
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
                pointOfContact.x >= currentPosition.x 
                    ? pointOfContact.x - currentPosition.x 
                    : currentPosition.x - pointOfContact.x,
                pointOfContact.y >= currentPosition.y 
                    ? pointOfContact.y - currentPosition.y 
                    : currentPosition.y - pointOfContact.y
            );
    }
    void MoveAwayFromPlayer(float distanceFromPlayer, Vector3 angleFromPlayer)
    {
        Debug.Log($"distanceFromPlayer: {distanceFromPlayer}");
        Debug.Log($"angleFromPlayer: {angleFromPlayer}");
        lerp.endPosition = new Vector3
        (
            distanceFromPlayer * angleFromPlayer.x,
            distanceFromPlayer * angleFromPlayer.y
        );
        lerp.lerpDuration = Stats.EnemyVelocity * distanceFromPlayer;
        lerp.condition = true;
    }
}

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
    float angleOfWall;
    float distanceFromPlayerToMaintain;
    float distanceFromWallToMaintain;
    public PlayerData playerData;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        transform = GetComponent<Transform>();
        lerp = GetComponent<EZLerp>();
        distanceFromPlayerToMaintain = 12.0f;
    }
    void Update()
    {
        Debug.Log($"  distance from player: {VectorFromPlayer().magnitude}");
        if(distanceFromPlayerToMaintain >= VectorFromPlayer().magnitude)
        {
            MoveAwayFromPlayer();
        }
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
            Debug.Log("Warning: Player is too close");
            MoveAwayFromPlayer(VectorFromPlayer().magnitude, VectorFromPlayer().normalized);
        }
        else if(collider.gameObject.CompareTag(Tags.Wall))
        {
            Debug.Log("Collided with wall");

        }
    }

    Vector3 VectorFromPlayer()
     // The distance between player's and enemy's position
     // @todo fix this because you did it wrong.
    {
        Vector3 currentPosition = new Vector3
        (
            transform.position.x,
            transform.position.y
        );
        Vector3 playerPosition = new Vector3
        (
            playerData.positionOnMap.x,
            playerData.positionOnMap.y
        );

        Debug.Log($"  Formation Position: {currentPosition} \n  Player Position: {playerPosition}");

        return new Vector3
        (
            // if playerPosition <= currentPosition, the point of contact is below the formation
            currentPosition.x + playerPosition.x,
            currentPosition.y + playerPosition.y
        );
    }
    void MoveAwayFromPlayer()
    {
        Vector3 endPosition = new Vector3(
            distanceFromPlayerToMaintain - VectorFromPlayer().x,
            distanceFromPlayerToMaintain - VectorFromPlayer().y
        );
        Debug.Log($"  distanceFromPlayerToMaintain: {distanceFromPlayerToMaintain} \n  VectorFromPlayer().x: {VectorFromPlayer().x} \n  VectorFromPlayer().y: {VectorFromPlayer().y}");
        lerp.Setup(
            endPosition,
            1.0f
        );
    }
    void MoveAwayFromPlayer(float distanceFromPlayer, Vector3 angleFromPlayer)
    {
        Vector3 endPosition = new Vector3
        (
            distanceFromPlayerToMaintain + (distanceFromPlayer * angleFromPlayer.x),
            distanceFromPlayerToMaintain + (distanceFromPlayer * angleFromPlayer.y)
        );
        lerp.Setup(endPosition, 1.0f);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Player/Ship", order = 0)]
public class PlayerData : ScriptableObject
{
    public Vector2 positionOnMap;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 nextWaypoint;
    public float cursorRadius; // For Thumbstick controls
    public float moveSpeed;
    public float rotationSpeed = 1.0f;

    // Testing values
}

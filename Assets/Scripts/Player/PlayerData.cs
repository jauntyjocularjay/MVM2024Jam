using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public Vector2 positionOnMap;
    public Vector3 moveDirection = new Vector3(0,0,0);
    public float cursorRadius; // For Thumbstick controls
    public float moveSpeed;
    public float rotationSpeed = 1.0f;

    // Testing values
}

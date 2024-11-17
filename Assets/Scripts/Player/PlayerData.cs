using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public Vector2 positionOnMap;
    public Vector2 moveDirection = new Vector2(0,0);
    public float cursorRadius;
    public float moveSpeed;

    // Testing values



}

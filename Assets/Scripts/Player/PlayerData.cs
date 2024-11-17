using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public Vector2 position;
    public float moveSpeed;
}

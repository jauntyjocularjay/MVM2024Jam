using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Ship/SkipDrive", order = 0)]
public class HelperShipData : ScriptableObject
{
    public PlayerData data;
    public float skipDriveDistance = 2.0f;
    void Ability()
    /*
     * @method Ability allows the skip drive to instantly teleport to a position as long as there are no
     *      solid objects in the way.
     */
    {
        data.positionOnMap = new Vector2(
            (data.moveDirection.x * skipDriveDistance) + data.positionOnMap.x,
            (data.moveDirection.y * skipDriveDistance) + data.positionOnMap.y
        );
    }
}

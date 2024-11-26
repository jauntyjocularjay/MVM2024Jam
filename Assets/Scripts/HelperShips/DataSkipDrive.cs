using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Helper/SkipDrive", order = 0)]
public class SkipDriveData : HelperShipData
/*
    SkipDriveData contains the logic, sprites (by inheritance), animator (by inheritance), Ability()
        The ability in this case jumps the player in the direction of the mouse cursor by the 
        float skipDriveDistance.
    @todo change the skip drive type, it no longer makes sense for it to be a HelperShipData
*/
{
    public float skipDriveDistance = 2.0f;
    override public void Ability()
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
    override public void Behavior()
    {}
}
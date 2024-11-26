using UnityEngine;

[CreateAssetMenu(fileName = "MissileLauncherData", menuName = "Helper/Missile", order = 4)]
public class DataMissileLauncher : HelperShipData
{
    void Awake()
    {
        type = ShipType.MissileLauncher;
    }
    override public void Ability()
    {}
}

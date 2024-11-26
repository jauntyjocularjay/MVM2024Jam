using UnityEngine;

[CreateAssetMenu(fileName = "TorpedoLauncherData", menuName = "Helper/Torpedo", order = 3)]
public class DataTorpedoLauncher : HelperShipData
{
    void Awake()
    {
        type = ShipType.TorpedoLauncher;
    }
    override public void Ability()
    {}
}

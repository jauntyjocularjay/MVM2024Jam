using UnityEngine;

[CreateAssetMenu(fileName = "TorpedoLauncherData", menuName = "Helper/Torpedo", order = 3)]
public class DataTorpedoLauncher : HelperShipData
{
    public GameObject projectilePrefab;
    override public void Ability()
    {}
}

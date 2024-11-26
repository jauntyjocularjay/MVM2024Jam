using UnityEngine;

[CreateAssetMenu(fileName = "PaviseData", menuName = "Helper/Pavise", order = 2)]
public class FighterPaviseData : HelperShipData
{
    void Awake()
    {
        type = ShipType.Pavise;
    }
    override public void Ability()
    {}
}

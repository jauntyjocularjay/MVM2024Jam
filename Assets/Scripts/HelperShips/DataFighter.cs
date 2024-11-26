using UnityEngine;

[CreateAssetMenu(fileName = "FighterData", menuName = "Helper/Fighter", order = 1)]
public class FighterData : HelperShipData
{
    void Awake()
    {
        type = ShipType.Fighter;
    }
    override public void Ability()
    {
        Shoot();
    }
    override public void Behavior()
    {
        
    }
    public void Shoot()
    {}

}

using UnityEngine;

public class Pavise : HelperShip
{
    public ShipType shipType = ShipType.Pavise;

    new void Start()
    {
        base.Start();
        HP = 7;
    }

    

}
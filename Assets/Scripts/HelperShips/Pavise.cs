using System.Collections.Generic;
using UnityEngine;

public class Pavise : HelperShip
{
    ShipType shipType = ShipType.Pavise;

    new void Start()
    {
        base.Start();
        HP = 7;
    }

    

}
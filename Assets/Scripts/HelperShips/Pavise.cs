using UnityEngine;

public class Pavise : HelperShip
{
    ShipType shipType = ShipType.Pavise;
    // private Pathwinder pathwinder;

    new void Start()
    {
        // pathwinder = GetComponent<Pathwinder>();
        base.Start();
        HP = 7;
        // pathwinder.Go();
    }

    

}
using UnityEngine;

public class TorpedoLauncher : HelperShip
{
    new void Start()
    {
        base.Start();
        HP = 5;
    }

    void Update()
    {
        /*
            hang back behind the player ship near the middle
            Fire when the player fires.
        */
    }
    void Shoot()
    /* Shoot 1 projectile at a time */
    {}
}

using UnityEngine;

public class Fighter : HelperShip
{
    new void Start()
    {
        base.Start();
        HP = 3;
    }

    void Update()
    {
        /*
            Bank to the left side when the player banks left
            Bank to the right side when the player banks to the right
            Strafe 3 shots to the left/right depending when the player fires
        */
    }
    void Shoot()
    /* Shoot 3 projectiles at a time */
    {}
}

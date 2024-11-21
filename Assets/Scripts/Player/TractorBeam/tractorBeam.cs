using UnityEngine;

public class tractorBeam : Weapon
{
    public override void OnShoot(Transform emitter, bool rapid)
    {
        emitter.gameObject.GetComponent<tractorBeamProjectile>().refillLife();
        emitter.gameObject.SetActive(true);
    }
}

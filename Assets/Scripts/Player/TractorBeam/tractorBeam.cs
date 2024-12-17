using UnityEngine;

public class TractorBeam : Weapon
{
    public override void OnShoot(Transform emitter, bool rapid)
    {
        emitter.gameObject.GetComponent<tractorBeamProjectile>().refillLife();
        emitter.gameObject.SetActive(true);
    }
}

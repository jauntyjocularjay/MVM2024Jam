using UnityEngine;

public class TractorBeam : Weapon
{
    public override void OnShoot(Transform emitter, bool rapid)
    {
        emitter.gameObject.GetComponent<TractorBeamProjectile>().refillLife();
        emitter.gameObject.SetActive(true);
    }
}

using EZLerps;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyFighter : EnemyShip
{
    new CapsuleCollider2D collider;
    ProjectileData projectileData;
    Pathwinder pathwinder;
    new void Start()
    {
        base.Start();
        pathwinder = GetComponent<Pathwinder>();
        pathwinder.velocity = 3;
        knockback = 2;
        if(pathwinder.path != null) pathwinder.Go();
    }

    new void Update()
    {
        base.Update();
    }

    void LastPointOffCamera()
    {
        Camera camera = Object.FindAnyObjectByType<Camera>();
        Vector3 endPosition = pathwinder.path.Position(pathwinder.path.LastIndex());
        endPosition.y = camera.GetComponent<Transform>().position.y - 2 * camera.orthographicSize - 2.0f;
        endPosition.z = 0.0f;
        pathwinder.path.SetPosition(pathwinder.path.LastIndex(), endPosition);
    }
}
